    // Copyright: Nothing At All License
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using MathNet.Numerics.Random;
    namespace HelpSO
    {
        public static class Program
        {
            [STAThread]
            public static void Main(params String[] arguments)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var mainForm = new MainForm();
                Application.Run(mainForm);
            }
        }
        /// <summary>
        /// Main Form.
        /// </summary>
        public class MainForm : Form
        {
            /// <summary>
            /// Initializes the chart and cosmetics, make-up, glamour, etc..
            /// </summary>
            /// <returns>The chart.</returns>
            private static Chart InitializeChart()
            {
                var chart = new Chart()
                {
                    Dock = DockStyle.Fill,      
                };
                const String defaultChartAreaName = @"Default";
                const String defaultLegendName = @"Default";
                const String defaultTitleName = @"Default";
                            
                var chartArea = chart.ChartAreas.Add(defaultChartAreaName);
                var labelFont = new Font(@"Tahoma", 8f);
                var axisX = chartArea.AxisX;
                var axisY = chartArea.AxisY;
                axisX.Title = @"X";
                axisY.Title = @"Y";
                axisX.LabelStyle.Format = axisX.LabelStyle.Format = "F4";
                axisX.TitleFont = axisY.TitleFont = labelFont;
                axisX.LabelStyle.Font = axisY.LabelStyle.Font = labelFont;
                axisX.TitleAlignment = axisY.TitleAlignment = StringAlignment.Far;
                axisX.MajorGrid.Enabled = axisY.MajorGrid.Enabled = true;
                axisX.MinorGrid.Enabled = axisY.MinorGrid.Enabled = true;
                axisX.MinorGrid.LineDashStyle = axisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                axisX.MinorGrid.LineColor = axisY.MinorGrid.LineColor = Color.Gainsboro;
                var legend = chart.Legends.Add(defaultLegendName);
                legend.TitleSeparator = LegendSeparatorStyle.ThickGradientLine;
                legend.BorderColor = Color.Black;
                legend.Title = "Legend";
                var title = chart.Titles.Add(defaultTitleName);
                title.Text = @"My Awesome interpolated data";
                title.Font = new Font(title.Font.FontFamily, 12f);
                MainForm.InitializeChartSeries(chart);
                return chart;
            }
            /// <summary>
            /// Initializes the chart series and related data (raw and interpolated).
            /// </summary>
            /// <param name="chart">Chart.</param>
            private static void InitializeChartSeries(Chart chart)
            {
                const String rawDataSeriesName = @"Raw Data";
                const String interpolatedDataSeriesName = @"Interpolated Data";
                var rawDataSeries = chart.Series.Add(rawDataSeriesName);
                var interpolatedDataSeriesSeries = chart.Series.Add(interpolatedDataSeriesName);
                rawDataSeries.ChartType = SeriesChartType.FastLine;
                interpolatedDataSeriesSeries.ChartType = SeriesChartType.Spline;
                rawDataSeries.BorderWidth = interpolatedDataSeriesSeries.BorderWidth = 2;
                var rawDataPoints = DataFactory.GenerateDummySine(10, 1, 0.25);
                var interpolatedDataPoints = DataFactory.Interpolate(rawDataPoints, 10);
                rawDataSeries.Points.DataBind(rawDataPoints, @"X", @"Y", String.Empty);
                interpolatedDataSeriesSeries.Points.DataBind(interpolatedDataPoints, @"X", @"Y", String.Empty);
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="HelpSO.MainForm"/> class.
            /// </summary>
            public MainForm()
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                var chart = MainForm.InitializeChart();
                this.Controls.Add(chart);
            }
        }
        /// <summary>
        /// Data Factory.
        /// </summary>
        public static class DataFactory
        {
            /// <summary>
            /// Generates a dummy sine.
            /// </summary>
            /// <returns>The dummy sine.</returns>
            /// <param name="count">Count.</param>
            /// <param name="amplitude">Amplitude.</param>
            /// <param name="noiseAmplitude">Noise amplitude.</param>
            public static IList<Point2D<Double, Double>> GenerateDummySine(UInt16 count, Double amplitude, Double noiseAmplitude)
            {
                if (count < 2)
                {
                    throw new ArgumentOutOfRangeException(@"count");
                }
                else
                {
                    var dummySinePoints = new List<Point2D<Double, Double>>();
                    var random = new Random();
                    var xStep = 1.0 / count;
                    for (var x = 0.0; x < 1.0; x += xStep) 
                    {
                        var y = amplitude * Math.Sin(2f * Math.PI * x) + random.NextDouble() * noiseAmplitude;
                        var dummySinePoint = new Point2D<Double, Double>(x, y);
                        dummySinePoints.Add(dummySinePoint);
                    }
                    return dummySinePoints;
                }
            }
        
            /// <summary>
            /// Interpolate the specified source.
            /// </summary>
            /// <param name="source">Source.</param>
            /// <param name="countRatio">Count ratio.</param>
            public static IList<Point2D<Double, Double>> Interpolate(IList<Point2D<Double, Double>> source, UInt16 countRatio)
            {
                if (countRatio == 0)
                {
                    throw new ArgumentOutOfRangeException(@"countRatio");
                }
                else if (source.Count < 2)
                {
                    throw new ArgumentOutOfRangeException(@"source");
                }
                else
                {
                    var rawDataPointsX = source.Select(item => item.X);
                    var rawDataPointsY = source.Select(item => item.Y);
                    // Could be done within one loop only... so far I'm pretty busy will update that example later
                    var xMin = rawDataPointsX.Min();
                    var xMax = rawDataPointsX.Max();
                    // Different Kinds of interpolation here... it's all up to you o pick up the one that's gonna match your own situation
                    // var interpolation = MathNet.Numerics.Interpolation.NevillePolynomialInterpolation.Interpolate(rawDataPointsX, rawDataPointsY);
                    var interpolation = MathNet.Numerics.Interpolation.CubicSpline.InterpolateNatural(rawDataPointsX, rawDataPointsY);
                    var listCopy = source.ToList();
                    var xStep = (xMax - xMin) / (source.Count * countRatio);
                    for (var x = xMin; x <= xMax; x += xStep)
                    {
                        var y = interpolation.Interpolate(x);
                        var point2D = new Point2D<Double, Double>(x, y);
                        listCopy.Add(point2D);
                    }
                    return listCopy;
                }
            }
        }
        // C# lacks, for ***now***, generic constraints for primitive "numbers"
        public struct Point2D<TX, TY>
            where TX : struct, IComparable, IFormattable, IConvertible, IComparable<TX>, IEquatable<TX>
            where TY : struct, IComparable, IFormattable, IConvertible, IComparable<TY>, IEquatable<TY>
        {
            public static Point2D<TX, TY> Empty = new Point2D<TX, TY>();
            public Point2D(TX x, TY y)
            {
                this._x = x;
                this._y = y;
            }
            // C# 6 I miss you here: sad
            private readonly TY _y;
            public TY Y
            {
                get
                {
                    return this._y;
                }
            }
            // and there too :-(
            private readonly TX _x;
            public TX X
            {
                get
                {
                    return this._x;
                }
            }
        }
    }
