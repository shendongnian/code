    class MyObject {
        private MyObject() {
        }
        private void Setup() {
            // do some configuration here
        }
        public static MyObject CreateObject() {
            MyObject obj = new MyObject();
            obj.Setup();
            return obj;   
        }
    }
