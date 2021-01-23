    public static class test
    {
        public static void Main()
        {
            dynamic test = new ClazzB();
            GetDecription(test);
        }
    
        public static void GetDecription(ClazzA someClazz)
        {
            Debug.WriteLine("I am here");
        }
    
        public static void GetDecription(ClazzB someClazz)
        {
            Debug.WriteLine("I want to be here");
        }
    }
