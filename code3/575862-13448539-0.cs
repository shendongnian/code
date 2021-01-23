    SqlConnection con = new SqlConnection("my connection ");
    
    SqlDataAdapter da = new SqlDataAdapter("select name,date from date where date between'"+ Convert.ToDateTime( datePicker2.SelectedDate.ToString("yyyyMMdd")+"' and  '"+ Convert.ToDateTime( datePicker3.SelectedDate.ToString("yyyyMMdd"))+"'",con);
    
    DataSet ds = new DataSet();
    
    da.Fill(ds, "entry");
    
    da.Dispose();
    
    dataGrid1.DataContext = ds.Tables["entry"].DefaultView; 
