    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TestZone
    {
        class Example
        {
            #region Types
            class MyValue
            {
                public int Value { get; set; }
    
                public override string ToString()
                {
                    return string.Format("MyValue(Value = {0})", Value);
                }
            }
            #endregion // Types
    
            #region Constants
            /// <summary>
            /// Our N
            /// </summary>
            private const int NumberOfArrays = 4;
    
            /// <summary>
            /// How many rows per dictionary
            /// </summary>
            private const int NumberOfRows = 10; 
            #endregion // Constants
    
            #region Fields
            private Dictionary<string, MyValue>[] _data = new Dictionary<string, MyValue>[NumberOfArrays]; 
            #endregion // Fields
    
            #region Constructor
            public Example()
            {
                for (var index = 0; index < _data.Length; index++)
                {
                    _data[index] = new Dictionary<string, MyValue>(NumberOfRows);
                }
            } 
            #endregion // Constructor
    
            public void GenerateRandomData()
            {
                var rand = new Random(DateTime.Now.Millisecond);
    
                foreach (var dict in _data)
                {
                    // Add a number of rows
                    for (var i = 0; i < NumberOfRows; i++)
                    {
                        var integer = rand.Next(10);    // We use a value of 10 so we have many collisions.
                        dict["ValueOf" + integer] = new MyValue { Value = integer };
                    }
                }
            }
    
            public void OuterJoin()
            {
                // To get the outer join, we have to know the expected N before hand, as this example will show.
                // Do multiple joins
                var query = from d0 in _data[0]
                            join d1 in _data[1] on d0.Key equals d1.Key into d1joined
                            from d1 in d1joined.DefaultIfEmpty()
                            join d2 in _data[2] on d1.Key equals d2.Key into d2joined
                            from d2 in d2joined.DefaultIfEmpty()
                            join d3 in _data[3] on d2.Key equals d3.Key into d3joined
                            from d3 in d3joined.DefaultIfEmpty()
                            select new
                                       {
                                           d0.Key,
                                           D0 = d0.Value,
                                           D1 = d1.Value,
                                           D2 = d2.Value,
                                           D3 = d3.Value,
                                       };
    
                foreach (var q in query)
                {
                    Console.WriteLine(q);
                }
            }
        }
    
        class Program
        {
    
            public static void Main()
            {
                var m = new Example();
                m.GenerateRandomData();
                m.OuterJoin();
    
            }
        }
    }
