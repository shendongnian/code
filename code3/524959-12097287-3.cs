    public class MySecond : MyBase {
        public MySecond(MyBase prototype) {
            this.CopyFromBase(prototype);
        }
        public DateDeleted { get; set; }
    }
