    using System.Collections.Generic;
    namespace PropertyDataDrivenTests
    {
        public static class DemoPropertyDataSource
        {
            private static readonly List<object[]> _data = new List<object[]>
                {
                    new object[] {1, true},
                    new object[] {2, false},
                    new object[] {-1, false},
                    new object[] {0, false}
                };
    
            public static IEnumerable<object[]> TestData
            {
                get { return _data; }
            }
        }
    }
