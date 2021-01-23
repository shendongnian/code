    public class TestPage : Page
    {
        private Random Generator {get;set;}
        public Test()
        {
            this.Generator = new Random();
        }
        private int randomNumber()
        {
            return this.Generator.Next(0, 100);
        }
    }
