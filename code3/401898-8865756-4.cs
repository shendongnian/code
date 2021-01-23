    In other words, this would simply work:
        // this doesn't need to be abstract.
        // just put all the common stuff inside.
        public class BaseDO
        {
            // as svick pointed out, these should also be properties.
            // you should *never* expose public fields in your classes.
            public string Name { get; set; }
            public DateTime? Date { get; set; }
        }
        // don't use the new keyword to hide stuff.
        // in most cases, you won't need that's behavior
        public class DerivedDO : BaseDO
        {
            // no need to repeat those properties from above,
            // only add **different ones**
            public string Code { get; set; }
        }
