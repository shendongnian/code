    public class ReferenceTest
    {
        public int j;
    }
    
    ReferenceTest test = new ReferenceTest();
    test.j = 0;
    ReferenceTest test2 = test;
    //test2 and test both point to the same memory location
    //thus everything within them is really one and the same
    test2.j++;
    Console.WriteLine(test.j);
    //Output: 1
