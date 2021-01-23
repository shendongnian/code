    [Export(typeof(IPlugin)]//i use metadata too
    public class Viewmodel1 {}
    [Export(typeof(IPlugin)]//i use metadata too
    public class Viewmodel2 {}
    [ResourceDictionaryExport]
    public partial class MyResourceDictionary 
    {
        public MyResourceDictionary ()
        {
            InitializeComponent();
        }
    }
