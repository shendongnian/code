        private void InitializeChart()
        {
             
           tChart1.Aspect.View3D = false;
            double[] GraphData_Mean = new double[3];
            GraphData_Mean[0] = 3;
            GraphData_Mean[1] = 11;
            GraphData_Mean[2] = 34;
        
            double[] GraphData_Max = new double[3];
            GraphData_Max[0] = 5;
            GraphData_Max[1] = 15;
            GraphData_Max[2] = 23;
        
            double[] GraphData_Min= new double[3];
            GraphData_Min[0] = 1;
            GraphData_Min[1] = 8;
            GraphData_Min[2] = 17;
        
            tChart1.Series.Clear();
            for (int i = 0; i < 3; i++)
            {
                Steema.TeeChart.Styles.ErrorBar errorBar = new Steema.TeeChart.Styles.ErrorBar(tChart1.Chart);
                Steema.TeeChart.Styles.Error error1 = new Steema.TeeChart.Styles.Error(tChart1.Chart);
                // Error Bar Series
                errorBar.Pen.Color = Color.Black;
                errorBar.ErrorPen.Width = 2;
                errorBar.Brush.Solid = true;
                errorBar.Brush.Color = Color.White;
                errorBar.Marks.Visible = false;
                errorBar.ErrorStyle = ErrorStyles.Top;
                errorBar.HorizAxis = HorizontalAxis.Bottom;
                errorBar.MultiBar = MultiBars.None;
                errorBar.Add(i, GraphData_Mean[i], (GraphData_Max[i] - GraphData_Mean[i]));
                errorBar.BarWidthPercent = 40;
                //  Error Series 
                error1.ErrorPen.Width = 2;
                error1.Brush.Solid = true;
                error1.Color = Color.Black;
                error1.Marks.Visible = false;
                error1.ErrorStyle = ErrorStyles.Bottom;
                error1.HorizAxis = HorizontalAxis.Top;
                error1.MultiBar = MultiBars.None;
                error1.ShowInLegend = false;
                error1.Add(i, GraphData_Mean[i], (GraphData_Mean[i] - GraphData_Min[i]));
                error1.BarWidthPercent = 40;
               }
    }
