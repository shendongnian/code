    var fromDate = new DateTime(DateTime.Now.Year,
    		 DateTime.Now.Month,
    		 DateTime.Now.Day,
    		 0,
    		 0,
    		 0);
    
    var toDate = new DateTime(DateTime.Now.Year,
    	  DateTime.Now.Month,
    	  DateTime.Now.Day,
    	  23,
    	  59,
    	  59);
    
    chart1.ChartAreas[0].AxisX.Minimum = fromDate.ToOADate();
    chart1.ChartAreas[0].AxisX.Maximum = toDate.ToOADate();
