    public class MyViewEngine : RazorViewEngine {
       public MyViewEngine() {
           this.MasterLocationFormats = new string[] {
               "PATH TO YOUR LAYOUT FILES", "ALTERNATIVE PATH"
           }
       }
    }
