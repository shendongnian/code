    public class ReferenceTest
    {
        public int j;
    }
    
    ReferenceTest test = new ReferenceTest();
    test.j = 0;
    ReferenceTest test2 = test;
    test2.j++;
    Console.WriteLine(test.j);
    //Output: 1
