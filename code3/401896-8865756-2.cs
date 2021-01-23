    In other words, this would simply work:
        public class BaseDO
        {
            public string Name;
            public DateTime? Date;
            etc...
        }
        public class DerivedDO : BaseDO
        {
            // no need to repeat those properties from above,
            // only add **different ones**
            public string Code { get; set; }
        }
