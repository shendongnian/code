    public void Foo
    {
        for(int i = 1; i < 100; i++)
        {
            if( i % 2 == 0 )
            {
                Console.WriteLine("Foo: " + i);
            }
            else
            {
                Console.WriteLine("Bar: " + i);
            }
        }
        Foo();
    }
