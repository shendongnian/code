    public class MyClass
    {
        private int[] backingArray;
        public int X
        {
            get
            {
                if (backingArray == null)
                    return -1;
                else
                    return backingArray[0];
            }
        }
        public MyClass(int[] array)
        {
            if (array.Length > 0)
                backingArray = array;
        }
    }
    
    class Main
    {
        void Main()
        {
            int[] array = new int[] { 2 };
    
            MyClass test = new MyClass(array);
            array[0] = 6;
            Console.WriteLine(test.X);//prints 6
        }
    }
