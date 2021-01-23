            public Form1()
         {
             InitializeComponent();
             InitializeChart();
         }
    
        // Steema.TeeChart.Styles.FastLine Series1;
    
         Timer timer1, timer2,timer3, timer4;
         Random r;
         DateTime dt;
       DateTime[] Xvalues1;
       double[] Yvalues1; 
         Steema.TeeChart.TChart tChart1, tChart2, tChart3,tChart4;
         private void InitializeChart()
         {
    
             tChart1 = new TChart();
             tChart2 = new TChart();
             tChart3 = new TChart();
             tChart4 = new TChart();
             this.Controls.Add(tChart1);
             this.Controls.Add(tChart2);
             this.Controls.Add(tChart3);
             this.Controls.Add(tChart4);
    
             //Initialize Locations and size
    
             this.Width = 908;
             this.Height = 600;
    
             //Location
             tChart1.Left = 12;
             tChart1.Top = 53;
             tChart2.Left = 468;
             tChart2.Top = 53;
             tChart3.Left = 12;
             tChart3.Top = 318;
             tChart4.Left = 468;
             tChart4.Top = 318;
    
             //Size
             tChart1.Width = 373;
             tChart1.Height = 236;
             tChart2.Width = 373;
             tChart2.Height = 236;
             tChart3.Width = 373; 
             tChart3.Height = 236;
             tChart4.Width = 373;
             tChart4.Height = 236;      
    
             tChart1.Aspect.View3D = false;
             tChart2.Aspect.View3D = false;
             tChart3.Aspect.View3D = false;
             tChart4.Aspect.View3D = false;
    
             tChart1.Legend.Visible = false;
             tChart2.Legend.Visible = false;
             tChart3.Legend.Visible = false;
             tChart4.Legend.Visible = false;
    
    
             tChart1.Panel.Gradient.Visible = false;
             tChart2.Panel.Gradient.Visible = false;
             tChart3.Panel.Gradient.Visible = false;
             tChart4.Panel.Gradient.Visible = false;
    
    
             tChart1.Axes.Bottom.AxisPen.Visible = false;
             tChart2.Axes.Bottom.AxisPen.Visible = false;
             tChart3.Axes.Bottom.AxisPen.Visible = false;
             tChart4.Axes.Bottom.AxisPen.Visible = false;
    
             tChart1.Axes.Left.AxisPen.Visible = false;
             tChart2.Axes.Left.AxisPen.Visible = false;
             tChart3.Axes.Left.AxisPen.Visible = false;
             tChart4.Axes.Left.AxisPen.Visible = false;
    
             //Series
             tChart1.AutoRepaint = false;
             tChart2.AutoRepaint = false;
             tChart3.AutoRepaint = false;
             tChart4.AutoRepaint = false;
         
             for (int i = 0; i < 4; i++)
             {
                 new Steema.TeeChart.Styles.FastLine(tChart1.Chart);
                 new Steema.TeeChart.Styles.FastLine(tChart2.Chart);
                 new Steema.TeeChart.Styles.FastLine(tChart3.Chart);
                 new Steema.TeeChart.Styles.FastLine(tChart4.Chart);
            
                 tChart1[i].XValues.DateTime=true;
                 tChart2[i].XValues.DateTime = true;
                 tChart3[i].XValues.DateTime = true;
                 tChart4[i].XValues.DateTime = true;
                 InitialDataSeries(tChart1[i]);
                 InitialDataSeries(tChart2[i]);
                 InitialDataSeries(tChart3[i]);
                 InitialDataSeries(tChart4[i]);
                
             }
    
             //Axes labels
             tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MM";
             tChart1.Axes.Bottom.Labels.Angle = 90;
             tChart2.Axes.Bottom.Labels.DateTimeFormat = "dd/MM";
             tChart2.Axes.Bottom.Labels.Angle = 90;
             tChart3.Axes.Bottom.Labels.DateTimeFormat = "dd/MM";
             tChart3.Axes.Bottom.Labels.Angle = 90;
             tChart4.Axes.Bottom.Labels.DateTimeFormat = "dd/MM";
             tChart4.Axes.Bottom.Labels.Angle = 90;
             tChart1.AutoRepaint = true;
             tChart2.AutoRepaint = true;
             tChart3.AutoRepaint = true;
             tChart4.AutoRepaint = true;
             tChart1.Refresh();
             tChart2.Refresh();
             tChart3.Refresh();
             tChart4.Refresh();
    
             //Timer
             timer1 = new Timer();
             timer1.Start();
             timer1.Interval = 100;
             timer1.Tick += new EventHandler(timer1_Tick);
    
         }
    
         void timer1_Tick(object sender, EventArgs e)
         {
             //See the chart data updated.
             tChart1[0].Visible = false;
             tChart1[1].Visible = false;
             tChart1[2].Visible = false;
             PopulateSeries(tChart1[3]);
             PopulateSeries(tChart2[3]);
             PopulateSeries(tChart3[3]);
             PopulateSeries(tChart4[3]);
         
         }
         private void PopulateSeries(Steema.TeeChart.Styles.Series Series1)
         {
             r = new Random();
             dt = DateTime.Now;
             tChart1.AutoRepaint = false;
             tChart2.AutoRepaint = false;
             tChart3.AutoRepaint = false;
             tChart4.AutoRepaint = false; 
             // show only 50 points - delete the rest
             while (Series1.Count > 10000)
             {
                 Series1.Delete(0);
                 
             }
             if (Series1.Count > 10000)
             {
                Series1.Delete(0);
                 
             }
             else
             {
                 for (int t = 0; t < 100; t++)
                 {
                    
                     Series1.Add(dt, r.Next(1000));
                     dt = dt.AddSeconds(15);
                 }
             }
             tChart1.AutoRepaint = true;
             tChart2.AutoRepaint = true;
             tChart3.AutoRepaint = true;
             tChart4.AutoRepaint = true;
             tChart1.Refresh();
             tChart2.Refresh();
             tChart3.Refresh();
             tChart4.Refresh();
         }
    
         private void InitialDataSeries(Steema.TeeChart.Styles.Series Series1)
         {    
             //Arrays
             dt = DateTime.Now;
             r = new Random();
             Xvalues1 = new DateTime[18000];
             Yvalues1 = new double[18000];
             (Series1 as Steema.TeeChart.Styles.FastLine).DrawAllPoints = false;
             for (int j = 0; j < 18000; j++)
             {
                 Xvalues1[j] = dt;
                 dt = dt.AddSeconds(15);
                 Yvalues1[j] = r.Next(1000);
             }
    
             Series1.Add(Xvalues1, Yvalues1);
         }
