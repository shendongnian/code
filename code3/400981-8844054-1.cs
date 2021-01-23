    var t = new Throne {
        Id = Guid.NewGuid(),
        //...
        King = new King {
            Id = Guid.NewGuid()
            //...
        }
    };
    
    context.Thrones.Add(t);
    context.SaveChanges();
