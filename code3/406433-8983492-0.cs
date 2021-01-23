        public static class StringExtensions
        {
            public static byte[] ToByteArray(this string str)
            {
                char[] arr = str.ToCharArray();
                byte[] byteArr = new byte[arr.Length];
    
                for (int i=0; i<arr.Length; ++i)
                {
                    switch (arr[i])
                    {
                        case '0': byteArr[i] = 0; break;
                        case '1': byteArr[i] = 1; break;
                        default: throw new Exception(arr[i]+" is not 0 or 1.");
                    }
                }
    
                return byteArr;
            }
        }
