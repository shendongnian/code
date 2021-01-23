    class A
    {
        public void MethodOne()
        {
            using (locker)
            {
                ...body...
            }
        }
    
        public void MethodTwo()
        {
            using (locker)
            {
                ...body...
            }
        }
    }
