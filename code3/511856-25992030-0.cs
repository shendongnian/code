       var data = bl.getAirlines();
       // If single object returned cast to List
       // Note that could be already a list of 1 item though!
        if (data.Count == 1)
        {
            var list = new List<object> { data };               
            GridView1.DataSource = list;
        }
        else
         // Bind to list of items returned
            GridView1.DataSource = data;
        
        GridView1.DataBind();
