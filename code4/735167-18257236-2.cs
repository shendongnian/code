			/// <summary>
			/// This alternative uses DP line simplification, which keeps every shape, but "simplifies" the shape, simply reducing
			/// the number of points.  This will not accomplish the goal of reducing the number of shapes, but will
			/// give you a reduced representation that matches the original features in cases where slowness is caused
			/// by too much detail, which can be useful if you still want to keep all your features.
			/// </summary>
			private void button2_Click(object sender, EventArgs e)
			{
				Shapefile source = new Shapefile();
				source = Shapefile.OpenFile(@"C:\Data\Rivers\River.shp");
				FeatureSet result = new FeatureSet(FeatureType.Line);
				result.Projection = source.Projection;
				result.CopyTableSchema(source);
				foreach (IFeature feature in source.Features) {
					LineString linestring = feature.BasicGeometry as LineString;
					if (linestring != null)
					{
						IList<Coordinate> points = linestring.Coordinates;
						IList<Coordinate> simplified = DouglasPeuckerLineSimplifier.Simplify(points, .00002);
						IFeature resultFeature = result.AddFeature(new LineString(simplified));
						resultFeature.CopyAttributes(feature);
					}
					else {
						MultiLineString multipleLines = feature.BasicGeometry as MultiLineString;
						if (multipleLines != null)
						{
							List<LineString> resultLines = new List<LineString>();
							foreach (IGeometry line in multipleLines.Geometries)
							{
								IList<Coordinate> points = line.Coordinates;
								IList<Coordinate> simplified = DouglasPeuckerLineSimplifier.Simplify(points, .00002);
								resultLines.Add(new LineString(simplified));
							}
							IFeature resultFeature = result.AddFeature(new MultiLineString(resultLines));
							resultFeature.CopyAttributes(feature);
						}
					}
				}
				result.SaveAs(@"C:\Data\Rivers\RiverSimplified.shp", true);
				MessageBox.Show(@"Finished creating file: C:\Data\Rivers\RiverSimplified.shp");
			}
