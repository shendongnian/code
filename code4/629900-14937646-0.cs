    class SomeClass 
    {
        public static bool SomeBool = false;
    }
    class SomeOtherClass
    {
        public void SomeMethod() 
        {
            Debug.Write(SomeClass.SomeBool); // Ouput = false
        }
    }
