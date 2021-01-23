    public static void Main(string[] args)
            {
                var charArray = new[] {'t', 'e', 's', 't'};
                fixed (char* charPointer = charArray)
                {
                    var charString = new string(charPointer);
                }
            }
