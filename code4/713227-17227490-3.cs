    public static class EnumExtensions
    {
        public static string ToSampleString(this SampleEnum enum)
        {
             switch(enum)
             {
                 case SampleEnum.Value1 : return "Foo";
                 etc.
             }
        }
    }
