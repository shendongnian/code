    var tumors = dc.Tumors
                   .Where(tumor => tumor.FK_Mouse == mouse.ID)
                   .Select(tumor => new { 
                       tumor.Name, 
                       Organs = tumor.Organs.Select(o => o.Name)
                   })
                   .AsEnumerable() // Switch to LINQ to Objects
                   .Select(tumor => new {
                       tumor.Name,
                       Organs = string.Join(", ", tumor.Organs)
                   });
