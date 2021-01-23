    [AttributeUsage(AttributeTargets.Method)]
    public class Ignore : Attribute { }
    [Ignore]
    public static void M() {
        var ignoreAttributes =
            MethodBase.GetCurrentMethod().GetCustomAttributes(typeof(Ignore), true);
        if (ignoreAttributes.Any()) {
            return;
        }
        // method execution proceeds
        // do something
    }
