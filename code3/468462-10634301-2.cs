     public class Seive
        {
            public Seive(String id)
            {
                SeiveIdSize = id;
                Caret = 0.0;
                Percent = 0.0;
                Peices = 0;
                Weight = 0.0;
                Size = 0;
            }
    
            public String SeiveIdSize { get; set; }
            public Double Weight { get; set; }
            public Double Percent { get; set; }
            public Double Caret { get; set; }
            public uint Size { get; set; }
            public uint Peices { get; set; }
        }
