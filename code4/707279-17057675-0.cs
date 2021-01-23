    using System.Linq;
    
    namespace EFDeleteTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (EFTestEntities context = new EFTestEntities())
                {                      
                    var child = context.Children.Single(c => c.Id == 1);
    
                    context.Children.Remove(child);
    
                    context.SaveChanges();
                }
            }
        }
    }
