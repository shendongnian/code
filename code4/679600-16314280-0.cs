    using (EntityFrameworkTestEntities context3 = new EntityFrameworkTestEntities())
    {
        context3.DisplayBoards.Add(newBoard);
        context3.SaveChanges();
    }
