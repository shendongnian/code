    using System.Reflection;
    using System.Web.Optimization;
    
    ...
    
    int count = ((ItemRegistry)typeof(Bundle).GetProperty("Items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(cssBundle, null)).Count;
