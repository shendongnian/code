        public class CustomEqualityComparer: IEqualityComparer<String>
        {
            public bool Equals(String str1, String str2)
            {
                //custom logic
            }
            public int GetHashCode(String str)
            {
                // custom logic
            }
        }
        //result
        var results = result.ToLookup(r => r.Name, 
                            new CustomEqualityComparer())
                            .Select(r => ....)
        
