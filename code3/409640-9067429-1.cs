    [ActionName("SomeMethod"), MatchesParam("value", typeof(int))]
    public ActionResult SomeMethodInt(int value)
    {
       // etc
    }
    
    [ActionName("SomeMethod"), MatchesParam("value", typeof(bool))]
    public ActionResult SomeMethodBool(bool value)
    {
       // etc
    }
    
    [ActionName("SomeMethod"), MatchesParam("value", typeof(List<int>))]
    public ActionResult SomeMethodList(List<int> value)
    {
       // etc
    }
    
    
    public class MatchesParamAttribute : ActionMethodSelectorAttribute
    {
         public string Name { get; private set; }
         public Type Type { get; private set; }
    
         public MatchesParamAttribute(string name, Type type)
         { Name = name; Type = type; }
    
         public override bool IsValidForRequest(ControllerContext context, MethodInfo info)
         {
                 var val = context.Request[Name];
    
                  if (val == null) return false;
    
                 // test type conversion here; if you can convert val to this.Type, return true;
    
                 return false;
         }
    }
