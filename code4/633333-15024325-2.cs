        private void InitializeChart()
        {
            mainTChart.Aspect.View3D = false;
            Line line1 = new Line(mainTChart.Chart);
            line1.XValues.DateTime = true;
            line1.FillSampleValues();
            mainTChart.Axes.Bottom.Labels.DateTimeFormat = "hh:mm";
            mainTChart.MouseDown += new MouseEventHandler(mainTChart_MouseDown);
        }
        double m_dblTempVolFromTo = 0;
        double dtFromTo = 0;
        void mainTChart_MouseDown(object sender, MouseEventArgs e)
        {
            if (!mainTChart.Axes.Bottom.IsDateTime && e.Button == MouseButtons.Right)
            {
                m_dblTempVolFromTo = mainTChart[0].XScreenToValue(e.X);
                mainTChart.ContextMenu = new ContextMenu();
                mainTChart.ContextMenu.MenuItems.Add(new MenuItem("From " + m_dblTempVolFromTo + " cc"));
                mainTChart.ContextMenu.MenuItems.Add(new MenuItem("To " + m_dblTempVolFromTo + " cc"));
                mainTChart.ContextMenu.MenuItems[0].Click += new EventHandler(From_Click);
                mainTChart.ContextMenu.MenuItems[1].Click += new EventHandler(To_Click);
            }
            else if (e.Button == MouseButtons.Right)
            {
                dtFromTo = mainTChart[0].XScreenToValue(e.X);
                String stFromTo = mainTChart.Axes.Bottom.Labels.LabelValue(dtFromTo);
                mainTChart.ContextMenu = new ContextMenu();
                mainTChart.ContextMenu.MenuItems.Add(new MenuItem("From " + stFromTo));
                mainTChart.ContextMenu.MenuItems.Add(new MenuItem("To " + stFromTo));
                mainTChart.ContextMenu.MenuItems[0].Click += new EventHandler(From_Click);
                mainTChart.ContextMenu.MenuItems[1].Click += new EventHandler(To_Click);
            }
        }
        void From_Click(object sender, EventArgs e)
        {
            mainTChart.Axes.Bottom.AutomaticMaximum = false;
            if (!mainTChart.Axes.Bottom.IsDateTime)
                mainTChart.Axes.Bottom.Maximum = m_dblTempVolFromTo;
            else
                mainTChart.Axes.Bottom.Maximum = dtFromTo;
        }
        void To_Click(object sender, EventArgs e)
        {
            mainTChart.Axes.Bottom.AutomaticMinimum = false;
            if (!mainTChart.Axes.Bottom.IsDateTime)
                mainTChart.Axes.Bottom.Minimum = m_dblTempVolFromTo;
            else
                mainTChart.Axes.Bottom.Minimum = dtFromTo;
        } 
