    public class MyBase {
        public DateAdded { get; set; }
        public MyBase() {
        }
        public MyBase(MyBase other) {
            // Do the copying here
        }
    }
    public class MySecond : MyBase {
        public MySecond(MyBase prototype) : base(prototype) {
        }
        public DateDeleted { get; set; }
    }
