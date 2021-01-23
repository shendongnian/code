     // Seperate construction from business logic
     public class Manager
     {
         public Manager(ICatRepository catRepository)
         {
             this.catRepository = catRepository;
         }
     }
