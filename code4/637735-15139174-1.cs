        public void MyMethod(string myParam1, string myParam2)
        {
            Console.WriteLine(myParam2);
        }
        public void MyMethod(string myParam1)
        {
            MyMethod(myParam1, myParam1);
        }
