     Dictionary<string, List<MyModel>> result = myItems
             .Where(myItem => !string.IsNullOrEmpty(myItem.Description))                                    
             .Select(ci => new MyModel
               {
                 Name = ci.Name,
                 Category =  ci.Description.Split('*')[0],
                 Description = ci.Description.Split('*')[2]
               })
             .GroupBy(e => e.Category)
             .ToDictionary(e => e.Key, e => e.ToList());
