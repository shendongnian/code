    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Show();
        Show();
    }
    static void Show()
    {
        using(var grid = new PropertyGrid
            {Dock = DockStyle.Fill, SelectedObject = new Foo { Bar = "def"} })
        using(var form = new Form { Controls = { grid }})
        {
            form.ShowDialog();
        }
    }
    class Foo
    {
        [CheekyDisplayName("abc")]
        public string Bar { get; set; }
    }
    public class CheekyDisplayNameAttribute : DisplayNameAttribute
    {
        public CheekyDisplayNameAttribute(string resourceId)
        : base(GetMessageFromResource(resourceId))
        { }
        private static string GetMessageFromResource(string resourceId)
        {
            return resourceId + Interlocked.Increment(ref counter);
        }
        private static int counter;
    }
