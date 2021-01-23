       public class CustomArray
            {
                private object[] _arr;
                public CustomArray(object[] arr)
                {
                    _arr = arr;
                }
        
                public object[] this[int index]
                {
                    get
                    {
                        // This indexer is very simple, and just returns or sets 
                        // the corresponding element from the internal array. 
                        return (object[]) _arr[index];
                    }
                }
                static void Main()
                {
                    var c = new CustomArray(new object[] { new object[] {1,2,3,4,5 }, new object[] {1,2,3,4 }, new object[] {1,2 } });
                    var a =(int) c[1][2]; //here a will be 4 as you asked.
                }
        
            }
