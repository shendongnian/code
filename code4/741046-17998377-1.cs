    // In some file somewhere
    namespace firstNamespace
    {
        Class MyString : String
        {
            public static TrimSafe() {}
        }
    }
    // The first file you copied from
    namespace firstNamespace
    {
        public void foo() { TrimSafe(); } // Works!
    }
    namespace secondNamespace
    {
        public void fee() { TrimSafe(); } // Nope :(
    }
