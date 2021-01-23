    public class JDE8Dal
        {
            public string conString { get; set; }
            private static readonly JDE8Dal _instance = new JDE8Dal();
            private JDE8Dal()
            {
            }
            public static JDE8Dal Instance
            {
                get { return _instance; }
            }
            // Methods
        }
