    public MyDelegateTypeThatMatchesMyFunctionCall DoAThingToAStringProperty { get; set; }
    
    public class AClassWhatever
    {
        protected virtual string DoAThingToAString(string inputString)
        {
            var handler = this.DoAThingToAStringProperty;
            if (handler)
            {
                return handler(inputString);
            }
            // do default behavior
            return inputString + "blah";
        } 
    }
