    List<int> tem = new List<int>();
    using (SqlConnection cs = new SqlConnection(connStr))
    {
        .....
        tem.Add(Convert.ToInt32(dr["TransTime"])); 
    }
    var ordered = tem.OrderByDescending(x => x).ToList();
    StringBuilder sb = new StringBuilder();
    ordered.ForEach(x => sb.AppendLine(x.ToString()));
    textBox.Text = sb.ToString();
    
        
