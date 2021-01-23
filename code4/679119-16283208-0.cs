        StringBuilder sb = new StringBuilder();
        foreach (string row in queryArray)
        {
            sb.Append(row).Append(Environment.NewLine);
        }
        
        context.Response.Write(sb.ToString()); 
