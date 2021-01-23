    public abstract class MyObj implements IMyObj {
        String name;
        public abstract String getName();
        public void test() {
            name = getName();
        }
    }
