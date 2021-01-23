    public class MyClass {
        private static long INSTANCE_ID = 0;
        private long ID;
        //ctor
        public MyClass() {
             this.ID = INSTANCE_ID++;
        }
        //You could build your string method based on the ID if you wanted to...
        public long getID() {
             return ID;
        }
    }
