    public interface ICoated {
        string Coating { get; set; }
    }
    
    public class Dog : ICoated {
        public string Coating {
            get { return Fur; }
            set { Fur = value; }
        }
    }
    
    public class Car: ICoated {
        public string Coating {
            get { return PaintJob; }
            set { PaintJob = value; }
        }
    }
