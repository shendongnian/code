        for (int i = 0; i < dsS.Tables[0].DefaultView.Count;i++) {
            double y = Convert.ToDouble(dsV1.Tables[0].DefaultView[i][1]) - Convert.ToDouble(dsS.Tables[0].DefaultView[i][1]);
            double x = Convert.ToDateTime(dsV1.Tables[0].DefaultView[i][0]).ToOADate();
            chartIndicators.Series["H"].Points.AddXY(x, y);                
        }
