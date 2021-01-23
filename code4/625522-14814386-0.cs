    class x
    {
        List<Something> listOne = new List<Something>();
        List<Something> listTwo = new List<Something>();
    
        void MethodOne()
        {
            lock (listOne)
            {
                // some operation on listOne
            }
        }
    
        void MethodTwo()
        {
            lock (listTwo)
            {
                // some operation on listTwo
            }
        }
    }
