    var DataSource = product.Select(p => new {
                                           Class = p.Class,
                                           Id = m.Id > 0 ? (new Make(m.Id)).ProductName 
                                                         : "none"
                                         });
    
