    public class YourObject {
        public static void MyClassMethod() { // "class method" is a static method
        }
        public void MyInstanceMethod() {
        }
    }
    // callable as..
    YourObject.MyClassMethod();
    // or..
    YourObject obj = new YourObject();
    obj.MyInstanceMethod(); // OK
