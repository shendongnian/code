        public void ResolveDynamic(dynamic obj)
        {
            Console.WriteLine(obj.Name);
            obj.Name = "Now I got a new name";
            Console.WriteLine(obj.dosomethingforme);
            obj.GreetMe();
        }
