    static Expression<Func<Item, MyClassFormat>> ItemToClassFormat()
    {
        return item => new MyClassFormat 
           {
               ID = item.ID, 
               Name = item.Name, 
               Status = item.Statuses.Name
           }
    }
