    class Test
    {
        private string random = (new Random()).Next(10000, 99999).ToString();
        private string saver = "";
        public void Method()
        {
            Console.WriteLine(random);
        }
        protected void otherMethod()
        {
            saver += random;
            Console.WriteLine(saver);
        }
    }
