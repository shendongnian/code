    List<Object> NewList = new List<Object>();
            for (int i = 0; i < 10; i++)
            {
                NewList.Add(new[]
                { 
                   new { Number = i, Name = string.Concat("name",i) }
              
                });
            }    
