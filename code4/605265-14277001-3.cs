    [Serializable]
    public class MyValidationAspect : AssemblyLevelAspect
    {
        public override bool CompileTimeValidate(_Assembly assembly)
        {
            IEnumerable<object> myAttributes = typeof (Program).GetCustomAttributes(inherit: true)
                                                               .Where(atr => atr.GetType() == typeof (MyAttribute));
    
            if (!myAttributes.Any())
                Message.Write(MessageLocation.Of(typeof (Program)), SeverityType.Error, "DESIGN1",
                              "You haven't marked {0} with {1}", typeof (Program), typeof (MyAttribute));
    
            return base.CompileTimeValidate(assembly);
        }
    }
