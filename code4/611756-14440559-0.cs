    using System.Linq;
    using System.Reflection;
    // ...
    
    var asmbly = Assembly.GetExecutingAssembly();
    var typeList = asmbly.GetTypes().Where(
            t => t.GetCustomAttributes(typeof (MyAttribute), true).Length > 0
    ).ToList();
