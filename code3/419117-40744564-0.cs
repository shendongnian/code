    public class Source {
        public int frmValue { get; set; }
        public int frmValue2 { get; set; }
    }
    public class Dest {
        public int Value { get; set; }
        public int Value2 { get; set; }
    }
    Mapper.Initialize(cfg => {
        cfg.RecognizePrefix("frm");
        cfg.CreateMap<Source, Dest>();
    });
