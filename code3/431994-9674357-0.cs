    public class HomeController
    {
         public void Index(int vars) 
         {
              return this.View(string.Format("view{0}", vars));
         }
    }
