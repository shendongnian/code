    public static class SomeUtilityClass
    {
        public static void DoTheAwesomez(this ISomeInterface obj, int count)
        {
            for(int i = 0 ; i < count ; i++)
            {
                obj.Foo();
                obj.Bar();
            }
        }
    }
