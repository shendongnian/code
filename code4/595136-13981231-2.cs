        public interface IDataBag
        {
           ...
        }
        public class DataBag : IDataBag
        {
           ...
        }
        public interface IPrettyBag : IDataBag
        {
            int Decoration1 { get; set; }
            int Decoration2 { get; set; }
        }
        public class BigBag : IPrettyBag
        {
            public int Decoration1 { get; set; }
            public int Decoration2 { get; set; }
        }
        public interface SmallBag : IPrettyBag
        {
            public int Decoration1 { get; set; }
            public int Decoration2 { get; set; }
        }
