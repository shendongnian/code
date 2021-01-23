    //Search
    Box box = dbContext.Boxes.FirstOrDefault(x => x.BoxId == 45);
                   
    //breakpoint here, change Name of Box by sql management studio
    
    //Refresh
    var context = ((IObjectContextAdapter)dbContext).ObjectContext;
    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, box);
    
    //Check refresh and if it is in context
    box = dbContext.Boxes.FirstOrDefault(x => x.BoxId == 45);
