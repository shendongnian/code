    namespace MyNamespace
    {
        public partial class MyData
        {
            public DateTime UnixDateTime
            {
                get
                {
                    return MyConversionMethod(this.UnixTime);
                }
            }
        }
    }
