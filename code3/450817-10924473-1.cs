    public static class ProjectionManager
    {
         ProjectionManager()
         {
              //The mapping exercise is AS SIMPLE as this if all you are doing is
              //using the exact same property names, it'll autowire
              //If you use different projections you can create complex maps see the link
              //above.
              Mapper.CreateMap<Account,AccountViewModel>();
              Mapper.CreateMap<AccountViewModel,Account>();
         }
         //Make yourself some handy extension methods for syntactic sugar
         public static AccountViewModel ConvertToViewModel(this Account x)
         {
              return Mapper.Map<Account,AccountViewModel>(x);
         }
         //Make yourself some handy extension methods for syntactic sugar
         public static Account ConvertFromViewModel(this AccountViewModel x)
         {
              return Mapper.Map<AccountViewModel,Account>(x);
         }
    }
