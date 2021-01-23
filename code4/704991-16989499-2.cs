    public class yourClass
    {
        public double CurrentTotal {get;set;}
    
        protected void yourButtonClickCode()
        {
            // use the proeprty ref here instead of the local
        }
        public yourClass()
        {
           if(System.IO.File.Exists(@"your file.txt"))
           {
               this.CurrentTotal = double.Parse( System.IO.File.ReadAllText(@"your file.txt"));
           }
           else
           {
               this.CurrentTotal = 0d;
           }
        }
        protected void onExit()
        {
           System.IO.File.WriteAllText(@"your path.txt", this.CurrentTotal.ToString());
        }    
    }
