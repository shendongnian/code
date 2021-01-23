            double[] xvals = new double[100];
            double[] yvals = new double[100];
            for (double i = 0; i < xvals.Length; i++)
            {
                xvals[(int)i] = i / 10;
                yvals[(int)i] = Math.Sin(i / 10);
            }
            
            var zgc = msGraphControl1.zedGraphControl1;
            var lineItem = zgc.GraphPane.AddCurve("Custom", xvals, yvals, Color.Blue);
            lineItem.Line.Style = DashStyle.Custom;
            lineItem.Line.Width = 3;
            lineItem.Line.DashOn = 5;
            lineItem.Line.DashOff = 10;
            
            //offset the next curve
            for (int i = 0; i < xvals.Length; i++)
            {
                xvals[i] = xvals[i] + 0.5;
                yvals[i] = yvals[i] + 0.05;
            }
            var lineItem2 = zgc.GraphPane.AddCurve("DashDotDot", xvals, yvals, Color.Red);
            lineItem2.Line.Width = 3;
            lineItem2.Line.Style = DashStyle.DashDotDot;
            //offset the next curve
            for (int i = 0; i < xvals.Length; i++)
            {
                xvals[i] = xvals[i] + 0.5;
                yvals[i] = yvals[i] + 0.05;
            }
            var lineItem3 = zgc.GraphPane.AddCurve("Solid", xvals, yvals, Color.Black);
            lineItem3.Line.Width = 3;
            lineItem3.Line.Style = DashStyle.Solid;
            
            zgc.AxisChange();
            zgc.Refresh();
