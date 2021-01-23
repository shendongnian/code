    public class SomeClass
    {
        public static IBy Some1 { get { return By.CssSelector("span[id$=spanEarth]"); } }
    
        public static IBy Some2 { get { return By.CssSelector("span[id$=spanWorm]"); } }
    
        public static IBy Some3 { get { return By.CssSelector("span[id$=spanJim]"); } }
    }
    ...
    var gridRow = Type.GetType(typeof(SomeOtherClassInSameNamespace)
                                  .AssemblyQualifiedName
                                  .Replace("SomeOtherClassInSameNamespace", "SomeClass"),
                               true, true);
    var rowList = gridRow.GetProperties(BindingFlags.Public | BindingFlags.Static)
                         .Where(p => p.PropertyType.Name.Contains("IBy"));
    int i = 0;
    foreach (var property in rowList)
    {
        string test = property.GetValue(null, null).ToString();
        ...
    }
