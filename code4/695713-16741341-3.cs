    public MyDelegateTypeThatMatchesMyFunctionCall DoAThingToAStringProperty { get; set; }
    
    public class AClassWhatever
    {
        protected string DoAThingToAString(string inputString)
        {
            var handler = this.DoAThingToAStringProperty;
            if (handler)
            {
                return handler(inputString);
            }
            // do default behavior
            return DoAThingToAStringInternal(inputString);
        } 
        protected virtual string DoAThingToAStringInternal(string inputString)
        {
            // do default behavior
            return inputString + "blah";
        } 
    }
    
