	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	using DotSpatial.Data;
	using DotSpatial.Projections;
	using DotSpatial.Topology;
	namespace WindowsFormsApplication3
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			private void button1_Click(object sender, EventArgs e)
			{
				Shapefile source = new Shapefile();
				source = Shapefile.OpenFile(@"C:\Data\Rivers\River.shp");
				bool[,] pointRepresented = new bool[1000, 1000];
				double width = source.Extent.Width;
				double height = source.Extent.Height;
				double dx = width / 1000;
				double dy = height / 1000;
				FeatureSet result = new FeatureSet(FeatureType.Line);
				result.Projection = KnownCoordinateSystems.Geographic.World.WGS1984; // lat lon in WGS84
				result.DataTable.Columns.Add("Index", typeof(int));
				int index = 0;
				foreach (ShapeRange shape in source.ShapeIndices) {
				
					bool started = false;
					List<LineString> linestrings = new List<LineString>();
					foreach (PartRange part in shape.Parts) {
						List<Coordinate> coords = new List<Coordinate>();
						foreach (Vertex vert in part) {
							int i = (int)((vert.X - source.Extent.MinX) / dx);
							int j = (int)((vert.Y - source.Extent.MinY) / dy);
							if (i > 999) {
								i = 999;
							}
							if (j > 999) {
								j = 999;
							}
							if (pointRepresented[i, j] == true) continue;
							coords.Add(new Coordinate(vert.X, vert.Y));
							pointRepresented[i, j] = true;
						}
						if (coords.Count > 0) {
							if (coords.Count == 1) {
								coords.Add(coords[0]); // add a duplicate "endpoint" to the line if we only have one point.
							}
							linestrings.Add(new LineString(coords));
						}
					}
					if (linestrings.Count > 0) {
						IFeature feature;
						if (linestrings.Count > 1)
						{
							feature = result.AddFeature(new MultiLineString(linestrings));
						}
						else {
							feature = result.AddFeature(linestrings[0]);
						}
						feature.DataRow["Index"] = index;
						index++;
					}
					result.SaveAs(@"C:\Data\Rivers\RiverPreview.shp", true);
				}
				MessageBox.Show(@"Finished creating file: C:\Data\Rivers\RiverPreview.shp");
			}
		}
	}
