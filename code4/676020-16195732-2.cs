    foreach (DataRow row in dt.Rows)
    {
        foreach (DataColumn c in dt.Columns)
    	    {           
            double oldVal = Convert.ToDouble(row[c]);
            double newVal = oldVal * -1;
            row[c] = newVal;
            this.Text = row[c].ToString();   
           }
    }
