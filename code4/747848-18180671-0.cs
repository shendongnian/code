    public class Class1
    {
        private class Class2
        {
            public void Add(int a, int b) // Method in Class 2
            {
                this.Add(a, b);
            }
        }
    
        public Class1() // constructor of Class 1
        { 
            class2 cs = new class2();
            cs.Add(4,5);
        }
    }
