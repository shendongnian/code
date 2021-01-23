     var connetionString = "..";
        using (var connection = new SqlConnection(connetionString))
        {       
          
         using(var command = new SqlCommand("SELECT COLUMN1, COLUMN2 FROM YOURTABLE", connection))
         { 
           connection.Open();
           var  dr = cmmand.ExecuteReader();
           if (dr.HasRows == false)
           {
             throw new Exception();
           }
           if (dr.Read())
           {
        
               textBox1.Text = dr[0].ToString();
               textBox2.Text = dr[1].ToString();
           }
    
         } 
    
    }
