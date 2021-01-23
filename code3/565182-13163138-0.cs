    using(var myContext = new MySiteDbContextClassName())
    {
         var selectedCustomer = myContext.Customers.FirstOrDefault(x => x.CustomerId == someCustomerId);
         if(selectedCustomer != null)
         {
              selectedCustomer.Favorites.Clear();
              myContext.SaveChanges();
         }
    }
