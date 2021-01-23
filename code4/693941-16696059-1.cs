    public class MyDbContext : DbContext
    {
      ....    
      public Farm LoadFarmById(int id)
      {
        Farm farm = this.Farms.Where(f => f.Id == id); // or whatever
        farm.FilteredFruits = myContext.Entry(myFarm)
                                       .Collection(f => f.Fruits)
                                       .Query()
                                       .Where(....)
                                       .ToList();
        return farm;
      }
    }
    ...
 
    var myFarm = myContext.LoadFarmById(1234);
