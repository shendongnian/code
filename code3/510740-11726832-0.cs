    public struct User {
        public string name;
        public string email;
        public int age;
    }
    or
    public struct User {
        public string name;
        public string email;
        //use a byte to hold a value between 0 and 255 (most people don't live to be 255)
        public byte age;
    }
