    /////inner
    
    using MyHostingNamespace;
    namespace ClassLibrary1
    {
       
    
        [Export("class2", typeof(MySubInterface))]
        class Class2 : MySubInterface
        {
            public string MyProperty { get; set; }
    
            public Class2()
            {
    
                MyProperty = "Class2";
            }
        }
    } 
    
    ////middle
    
    using MyHostingNamespace;
    namespace ClassLibrary1
    {
    
    
        [Export("class1", typeof(MyInterface))]
        public class Class1 : MyInterface
        {
            [Import("class2", AllowDefault=true)]
            MySubInterface myClass2;
    
            public string MyProperty {get;set;}
    
            public Class1()
            {
    
                AggregateCatalog catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
                CompositionContainer _container = new CompositionContainer(catalog);
                _container.ComposeParts(this);
    
                MyProperty = myClass2.MyProperty;
            }
        }
    }
    
    ////outer
    
    namespace MyHostingNamespace
    {
        class Program
        {
            [Import("class1")]
            public MyInterface class1;
    
            public Program()
            {
                AggregateCatalog catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
                catalog.Catalogs.Add(new DirectoryCatalog("."));
                CompositionContainer _container = new CompositionContainer(catalog);
    
                _container.ComposeParts(this);
    
            }
    
            static void Main(string[] args)
            {
    
                Program p = new Program();
                
                Console.WriteLine(p.class1.MyProperty);
    
            }
    
        }
    
    
    
        public interface MyInterface
        {
            string MyProperty { get; set; }
        }
    
        public interface MySubInterface
        {
            string MyProperty { get; set; }
        }
    }
