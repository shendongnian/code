    static void Main()
        {
            int whichClass = 0;
            TestAbstract clTest ;
            if (whichClass == 0)
            {
                //repeat code
                clTest = new ClassA();
            }
            else if (whichClass == 1)
            {
                //repeat code
                clTest = new ClassB();
            }
            else if (whichClass == 10)
            {
                //repeat code
               clTest = new ClassX();
         
            }
            clTest.MainFunc();
        }
