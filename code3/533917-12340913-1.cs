    class T
    {
        public T next;
        public int otherfield;
        public T( T next, int otherfield )
        {
            this.next = next;
            this.otherfield = otherfield
        }
    }
    
    T[] r1 = new T[]{ new T( null, 1 ), new T( null, 2 ) };
    T[] s1 = new T[]{ new T( r1[0], 3 ), new T( null, 4 ) };
