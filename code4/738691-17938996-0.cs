    class A{
            public void display()
            {
                    Console.WriteLine("In class A");
            }
    }
    class B:A{
            public void display()
            {
                    Console.WriteLine("In class B");
            }
            public void show()
            {
                    base.display();
            }
    }
