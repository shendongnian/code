    public class FooFactoryInstanceProvider : StandardInstanceProvider
    {
        protected override string GetName(MethodInfo methodInfo, object[] arguments)
        {
            // harvest the 1st factory method arg, cast as appropriate 
            string fooParamOne = (string)arguments[0];  // ex. "Blue"
    
            // harvest the 2nd factory method arg, cast as appropriate 
            string fooParamTwo = (string)arguments[1];  // ex. "FiftyTwo"
    
            // manipulate the params to come up with the **Name** of the 
            //  IFoo implementation you want
            var fooName = GetFooName(fooParamOne, fooParamTwo);
    
            return fooName; // ex. "BlueFiftyTwoFoo"
        }
    
        protected override ConstructorArgument[] GetConstructorArguments(MethodInfo methodInfo, object[] arguments)
        {
            // skip the number of params you're using above to come up with the implementation name
            return base.GetConstructorArguments(methodInfo, arguments).Skip(2).ToArray();
        }
    
        private string GetFooName(string fooParamOne, string fooParamTwo)
        {
            // do that voodoo that you do
            return fooParamOne + fooParamTwo + "Foo";
        }
    }
