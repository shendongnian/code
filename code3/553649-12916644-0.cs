    public partial class PocoGenerator
        {
            public string Namespace { get; set; }
            public string Inherit { get; set; }
            public DatabaseInfo Schema { get; set; }
            public bool Contract { get; set; }
            public string SavePath { get; set; }
        }
