      string joinedSetOfQns= string.Join(",", 
           Enumerable.Range(0, dt.Rows.Count)
            .SelectMany(i => Enumerable.Range(0, dt.Columns.Count)
            .Select(j => array_questions[i, j])));    
                   Response.Write(joinedSetOfQns + Environment.NewLine);  
