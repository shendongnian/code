        class SomeClass
        {
            public vector myVector;
            public SomeClass()
            {
                myVector = new vector(10, 20);
            }
            public void MutateStruct(int newX)
            {
                myVector.x = newX;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                SomeClass me = new SomeClass();
                me.MutateStruct(200);
                int newerX = me.myVector.x; // newerX is now 200
                Console.Read();
            }
        }
