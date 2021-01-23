     Timer timer;
        private Steema.TeeChart.Tools.ColorBand tool;
        Steema.TeeChart.Styles.FastLine primaryLine;
        double w = 0;
        bool enabled = false;
    
        public Form1()
        {
            InitializeComponent();
            initPrimaryGraph();
            initTool();
    
            timer = new Timer();
            //Enable Timer
            timer.Enabled = true;
            timer.Interval = 50;
            timer.Tick += timer_Tick;
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
    
            AnimateSeries(tChart1);
        }
    
        private void AnimateSeries(TChart tChart)
        {
            Random rnd = new Random();
            tChart.AutoRepaint = false;
            primaryLine.BeginUpdate();
            foreach (Steema.TeeChart.Styles.Series s in tChart.Series)
            {         
                for (int i = 0; i < 2048; i++)
                {
                    primaryLine.XValues[i] = i;
                    primaryLine.YValues[i] = 20 + rnd.Next(50);
                }
    
            }
            
            tChart.AutoRepaint = true;
            primaryLine.EndUpdate();
        }
        private void initTool()
        {
            tool = new Steema.TeeChart.Tools.ColorBand();
            tChart1.Tools.Add(tool);
            tool.Axis = tChart1.Axes.Bottom;
            tool.Start = 300;
            tool.End = 400;
            tool.Brush.Color = Color.Yellow;
            tool.Pen.Color = Color.Blue;
            tool.Pen.Width = 2;
            tool.Transparency = 60;
    
            tool.StartLine.AllowDrag = true;
            tool.StartLine.DragRepaint = true;
            tool.ResizeStart = true;
            tool.StartLine.DragLine += new EventHandler(StartLine_DragLine);
    
            tool.EndLine.AllowDrag = true;
            tool.EndLine.DragRepaint = true;
            tool.ResizeEnd = true;
            tool.EndLine.DragLine += new EventHandler(EndLine_DragLine);
        }
    
        void StartLine_DragLine(object sender, EventArgs e)
        {
            if (enabled)
            {
                tool.End = tool.Start + w;
            }
        }
    
        void EndLine_DragLine(object sender, EventArgs e)
        {
            if (enabled)
            {
                tool.Start = tool.End - w;
            }
        }
    
        private void initPrimaryGraph()
        {
            tChart1.Header.Visible = true;
            tChart1.Aspect.View3D = false;
    
            tChart1.Walls.Back.Visible = false;
            tChart1.Walls.Bottom.Visible = false;
            tChart1.Walls.Left.Visible = false;
            tChart1.Walls.Right.Visible = false;
    
            tChart1.Legend.Visible = false;
            tChart1.BackColor = Color.Black;
            tChart1.Panel.Visible = false;
    
            //PRIMARY GRAPH.....
            primaryLine = new Steema.TeeChart.Styles.FastLine();
            tChart1.Series.Add(primaryLine);
            Random rnd = new Random();
            for (int i = 0; i < 2048; i++)
            {
                double x = i;
                double y = 20 + rnd.Next(50);
                primaryLine.Add(x, y);
            }
            primaryLine.LinePen.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            primaryLine.LinePen.Color = Color.White;
            primaryLine.LinePen.Width = 1;
            //AXES
            tChart1.Axes.Bottom.Automatic = false;
            tChart1.Axes.Bottom.Minimum = primaryLine.XValues.Minimum;
            tChart1.Axes.Bottom.Maximum = primaryLine.XValues.Maximum;
            tChart1.Axes.Bottom.Increment = 200; 
            tChart1.Axes.Bottom.Labels.Font.Color = Color.White;
            tChart1.Axes.Bottom.Grid.Visible = false;
            tChart1.Axes.Left.Automatic = false;
            tChart1.Axes.Left.Minimum = 0;
            tChart1.Axes.Left.Maximum = 300;
    
            tChart1.Axes.Left.Labels.Font.Color = Color.White;
            primaryLine.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Left;
            tChart1.Draw();
        }
    
        private void tool_DragLine(object sender, EventArgs e)
        {
            Steema.TeeChart.Tools.ColorLine t = sender as Steema.TeeChart.Tools.ColorLine;
            this.Text = t.Value.ToString();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                button1.Text = "Start";
            }
            else
            {
                timer.Start();
                button1.Text = "Stop";
            }
        }
    
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
