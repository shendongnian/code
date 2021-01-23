    public class MyClass : SomeBaseClass
    {
        public override DateTime ResolveDate(object someinput)
        {
            if (ConditionMet(someinput))
                return ResolveDateMyLogic(someinput);
    
            return ResolveDateUsingBaseLogic(someinput);
        }
    
        private bool ConditionMet(object someInput)
        {
            return true;
        }
    
        private DateTime ResolveDateMyLogic(object someinput)
        {
            return DateTime.Now;
        }
    
        protected virtual DateTime ResolveDateUsingBaseLogic(object someinput)
        {
            return base.ResolveDate(someinput);
        }
    }
