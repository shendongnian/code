    public class CustomAttribute : Attribute {
        public static List<MethodInfo> MethodsList = new List<MethodInfo>();
        static CustomAttribute() {
            var methods = Assembly.GetExecutingAssembly() //Use .GetCallingAssembly() if this method is in a library, or even both
                      .GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(CustomAttribute), false).Length > 0)
                      .ToList();
            MethodsList = methods;
        }
        public string fullMethodPath;
        public bool someThing;
        public  CustomAttribute([CallerMemberName] string membername = "") {
            var method = MethodsList.FirstOrDefault(m=>m.Name == membername);
            if (method == null || method.DeclaringType == null) return; //Not suppose to happen, but safety comes first
            fullMethodPath = method.DeclaringType.Name + membername; //Work it around any way you want it
            //  I need here to get the type of membername parent. 
            //  Here I want to get CustClass, not fooBase
        }
    }
