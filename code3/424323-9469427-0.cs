    public class MyOptions
    {
      public int n;
    }
    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
      return Assembly.LoadFrom(@"C:\windwos\test.dll");
    }
    static void Main(string[] args)
    {
      MyOptions ass = new MyOptions();
      AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
      StringWriter sw = new StringWriter();
      XmlSerializer serializer = new XmlSerializer(ass.GetType(), new Type[] { typeof(MyOptions) });
      serializer.Serialize(sw, ass);
      //more code writing in an xml file
      AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
    }
