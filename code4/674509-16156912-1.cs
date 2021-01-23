    public class MyGuy
    {
    
        public int Life { get; set; }
   
        public MyGuy()
        {
            this.Life = 100; // starting life
        }
  
        public Hit()
        {
            Random randomhit = new Random();
            int randomNumberhit = randomhit.Next(1, 4);
            this.Life -= randomNumberhit;
            Console.WriteLine(this.Life);
        }
    }
