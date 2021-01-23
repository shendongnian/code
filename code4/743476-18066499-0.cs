      class A
        {
            public int a = 0;
            public void display()
            {
                Console.WriteLine("The value of a is " + a);
            }
    
           public A Copy()
        {
            A a = new A();
            a.a = = this.a;
            return a;
        }
    
    
    
        }
