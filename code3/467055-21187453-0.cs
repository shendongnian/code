    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using AForge.Imaging;
    using WeifenLuo.WinFormsUI.Docking;
    namespace ImageFunctions.Forms
    {
    	public partial class FrmHistogram : DockContent
    	{
    		public delegate void HistogramStatus(string Message);
    		public event HistogramStatus histogramStatus;
    		public delegate void HistogramCompleted(string Message);
    		public event HistogramCompleted histogramCompleted;
    
    		private Stopwatch swHistogram = new Stopwatch();
    		private bool IsHorizontalIntensity { get; set; }
    		private string CurrentImage = null;
    		private System.Windows.Forms.DataVisualization.Charting.Chart chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
    
    		public FrmHistogram()
    		{
    			InitializeComponent();
    			chart.Dock = DockStyle.Fill;
    			chart.BackColor = Color.LightYellow;
    			chart.ChartAreas.Add("Default");
    			this.Controls.Add(chart);
    			IsHorizontalIntensity = true; // Default.
    		}
    
    		protected override string GetPersistString()
    		{
    			return this.Text;
    
    		}
    
    		#region Histogram
    
    		/// <summary>
    		/// Build the Histogram for Supplied Image
    		/// </summary>
    		/// <param name="image">
    		/// String: Path to image that histogram is to be created out of
    		/// </param>
    		public void DoHistogram(string image)
    		{
    			CurrentImage = image; // Used for re-generating the histogram
    			bool IsGrayScale = AForge.Imaging.Image.IsGrayscale(new Bitmap(image));
    			dynamic IntensityStatistics = null; // Use dynamic (a little like var) to assign this variable which maybe of different types.
    
    			swHistogram.Reset();
    			swHistogram.Start();
    			histogramStatus("Creating Histogram");
    
    			AForge.Math.Histogram grayhist;
    			AForge.Math.Histogram Redhist;
    			AForge.Math.Histogram Greenhist;
    			AForge.Math.Histogram Bluehist;
    			// collect statistics
    			//NOTE: We have to use the braces on these statements see: http://stackoverflow.com/questions/2496589/variable-declarations-following-if-statements
    			if (IsHorizontalIntensity)
    			{
    				histogramStatus("Using HorizontalIntensityStatistics");
    				IntensityStatistics = new HorizontalIntensityStatistics(new Bitmap(image));
    			}
    			else
    			{
    				histogramStatus("Using VerticalIntensityStatistics");
    				IntensityStatistics = new VerticalIntensityStatistics(new Bitmap(image));
    			}
    
    			// get gray histogram (for grayscale image)
    			if (IsGrayScale)
    			{
    				grayhist = IntensityStatistics.Gray;
    				//TODO: DoGrayHistogram();
    				histogramStatus("Grayscale Histogram");
    			}
    			else
    			{
    
    				Redhist = IntensityStatistics.Red;
    				Greenhist = IntensityStatistics.Green;
    				Bluehist = IntensityStatistics.Blue;
    				DoRGBHistogram(Redhist, Greenhist, Bluehist);
    				histogramStatus("RGB Histogram");
    			}
    
    			swHistogram.Stop();
    			histogramCompleted("Histogram built in " + swHistogram.Elapsed);
    
    		}
    
    		private void DoRGBHistogram(AForge.Math.Histogram RedHist, AForge.Math.Histogram GreenHist, AForge.Math.Histogram BlueHist)
    		{
    
    
    			// Decide which set of values are placed at back, in the middle and to the front of the graph.
    			List<double> lis = new List<double>();
    			lis.Add(RedHist.Mean);
    			lis.Add(GreenHist.Mean);
    			lis.Add(BlueHist.Mean);
    			lis.Sort();
    
    			try
    			{
    				chart.Series.Add("Red");
    				chart.Series.Add("Green");
    				chart.Series.Add("Blue");
    
    				// Set SplineArea chart type
    				chart.Series["Red"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
    				chart.Series["Green"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
    				chart.Series["Blue"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
    				// set line tension
    				chart.Series["Red"]["LineTension"] = "0.8";
    				chart.Series["Green"]["LineTension"] = "0.8";
    				chart.Series["Blue"]["LineTension"] = "0.8";
    				// Set colour and transparency
    				chart.Series["Red"].Color = Color.FromArgb(50, Color.Red);
    				chart.Series["Green"].Color = Color.FromArgb(50, Color.Green);
    				chart.Series["Blue"].Color = Color.FromArgb(50, Color.Blue);
    				// Disable X & Y axis labels
    				chart.ChartAreas["Default"].AxisX.LabelStyle.Enabled = false;
    				chart.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;
    				chart.ChartAreas["Default"].AxisX.MinorGrid.Enabled = false;
    				chart.ChartAreas["Default"].AxisX.MajorGrid.Enabled = false;
    				chart.ChartAreas["Default"].AxisY.MinorGrid.Enabled = false;
    				chart.ChartAreas["Default"].AxisY.MajorGrid.Enabled = false;
    			}
    			catch (Exception)
    			{
    				// Throws an exception if it is already created.
    			}
    			chart.Series["Red"].Points.Clear();
    			chart.Series["Green"].Points.Clear();
    			chart.Series["Blue"].Points.Clear();
    
    			foreach (double value in RedHist.Values)
    			{
    				chart.Series["Red"].Points.AddY(value);
    			}
    			foreach (double value in GreenHist.Values)
    			{
    				chart.Series["Green"].Points.AddY(value);
    			}
    			foreach (double value in BlueHist.Values)
    			{
    				chart.Series["Blue"].Points.AddY(value);
    			}
    
    		}
    
    		#endregion
    
    		/// <summary>
    		/// If the Horizontal Intensity is checked then set the IsHorizontalIntensity to true
    		/// </summary>
    		/// <param name="sender"></param>
    		/// <param name="e"></param>
    		private void horizontalIntensityMenuItem_Click(object sender, EventArgs e)
    		{
    			ToggleMenu();
    			if (horizontalIntensityMenuItem.Checked) IsHorizontalIntensity = true;
    			DoHistogram(CurrentImage);
    		}
    
    		/// <summary>
    		/// The two options Horizontal & Vertical are Mutually exclusive this make sure that both options are not checked at the same time
    		/// One is checked as default - the other is not, so they will swap around.
    		/// </summary>
    		private void ToggleMenu()
    		{
    			horizontalIntensityMenuItem.Checked = !horizontalIntensityMenuItem.Checked; // Toggle this
    			verticalIntensityMenuItem.Checked = !verticalIntensityMenuItem.Checked; // Toggle this
    		}
    
    		/// <summary>
    		/// If the Horizontal Intensity is checked then set the IsHorizontalIntensity to False
    		/// </summary>
    		/// <param name="sender"></param>
    		/// <param name="e"></param>
    		private void verticalIntensityMenuItem_Click(object sender, EventArgs e)
    		{
    			ToggleMenu();
    			if (horizontalIntensityMenuItem.Checked) IsHorizontalIntensity = false;
    			DoHistogram(CurrentImage);
    		}
    
    
    
    
    	}
    }
