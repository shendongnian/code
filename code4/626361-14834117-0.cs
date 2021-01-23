    var productDTO = (from q in productResults 
                     select new Models.ProductDTO
                     {
                          Id = q.ProductId,
                          Name = q.Name.ToString(),
                          Year = q.Year.ToString("MMM ddd d HH:mm yyyy"),
                          Model = q.Model,
                          Description = q.Description.ToString()
                     }).Distinct().ToList().AsParallel();
                         
