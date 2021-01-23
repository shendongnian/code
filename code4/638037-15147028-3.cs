    public partial class StringVector: IDisposable, System.Collections.IEnumerable
    #if !SWIG_DOTNET_1
        , System.Collections.Generic.IList<string>
    #endif
    {
        // cast from C# string array
        public static implicit operator StringVector(string[] inVal) {
            var outVal= new StringVector();
            foreach (string element in inVal) {
                outVal.Add(element);
            }
            return outVal;
        }
    
        // cast to C# string array
        public static implicit operator string[](StringVector inVal) {
            var outVal= new string[inVal.Count];
            inVal.CopyTo(outVal);
            return outVal;
        }
    }
