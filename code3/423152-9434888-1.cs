            List<string> Results = new List<string>();
            int MaxFields = 5;
            Results.AddRange(message.Split(delimiter));
            if(Results.Count < MaxFields)
                Results.AddRange(Enumerable.Repeat(String.Empty,MaxFields - Results.Count)); 
            Id = Results[0]; 
            Property1 = Results[1];  
            Property2 = Results[2]; 
            Property3 = Results[3]; 
            Property4 = Results[4]; 
