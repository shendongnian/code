    // FakeChart.cs
    // ------------------------------------------------------------------
    //
    // A Winforms app that produces a contrived chart using
    // DataVisualization (MSChart).  Requires .net 4.0.
    //
    // Author: Dino
    //
    // ------------------------------------------------------------------
    //
    // compile: \net4.0\csc.exe /t:winexe /debug+ /R:\net4.0\System.Windows.Forms.DataVisualization.dll FakeChart.cs
    //
    
    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    
    
    namespace Dino.Tools.WebMonitor
    {
        public class FakeChartForm1 : Form
        {
            private System.ComponentModel.IContainer components = null;
            System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    
            public FakeChartForm1 ()
            {
                InitializeComponent();
            }
    
            private double f(int i)
            {
                var f1 = 59894 - (8128 * i) + (262 * i * i) - (1.6 * i * i * i);
                return f1;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                chart1.Series.Clear();
                var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "Series1",
                    Color = System.Drawing.Color.Green,
                    IsVisibleInLegend = false,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Line
                };
    
                this.chart1.Series.Add(series1);
    
                for (int i=0; i < 100; i++)
                {
                    series1.Points.AddXY(i, f(i));
                }
                chart1.Invalidate();
            }
    
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
                this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
                ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
                this.SuspendLayout();
                //
                // chart1
                //
                chartArea1.Name = "ChartArea1";
                this.chart1.ChartAreas.Add(chartArea1);
                this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
                legend1.Name = "Legend1";
                this.chart1.Legends.Add(legend1);
                this.chart1.Location = new System.Drawing.Point(0, 50);
                this.chart1.Name = "chart1";
                // this.chart1.Size = new System.Drawing.Size(284, 212);
                this.chart1.TabIndex = 0;
                this.chart1.Text = "chart1";
                //
                // Form1
                //
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.chart1);
                this.Name = "Form1";
                this.Text = "FakeChart";
                this.Load += new System.EventHandler(this.Form1_Load);
                ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
                this.ResumeLayout(false);
            }
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FakeChartForm1());
            }
        }
    }
