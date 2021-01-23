    private class T_Parameters
    {
        public char[] Name { get; private set; } 
        public byte YearsOld { get; set; } 
        public byte Day { get; set; } 
        public T_Parameters() {
            Name = new char[16];
        }
    }
