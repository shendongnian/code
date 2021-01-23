    public class CustomEncoding : Encoding
    {
        public override byte[] GetBytes(string s)
        {
            //Your code goes here            
        }
        public override string GetString(byte[] bytes)
        {
            //Your code goes here
        }
        //And many other virtual (overridable) methods which you can override to implement your custom Encoding fully
    }
