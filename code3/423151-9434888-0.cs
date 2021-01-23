            List<string> Results = new List<string>();
            int MaxFields = 5;
            Results.AddRange(message.Split(delimiter));
            if(Results.Count < MaxFields)
                Results.AddRange(Enumerable.Repeat(String.Empty,MaxFields - Results.Count)); 
