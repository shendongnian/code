    class PrivateMethod {
        public int pretendMain() {
            PrivateMethod x = new PrivateMethod();
            return x.myPrivateMethod();
        }
        private int myPrivateMethod() {
            return 1;
        }
    }
    class Program {
        static void Main(string[] args) {
            Program myProgram = new Program();
            myProgram.iAmPrivate("private");
            myProgram.iAmPublic("public");
            PrivateMethod pm = new PrivateMethod();
            Console.WriteLine("this will now run {0}", pm.pretendMain()); //now possible !
            //Console.WriteLine("this won't run {0}", pm.myPrivateMethod);  //not possible          
            Console.WriteLine("press [enter] to exit");
            Console.ReadLine();
        }
        public void iAmPublic(string s) {
            Console.WriteLine("I am {0}", s);
        }
        private void iAmPrivate(string s) {
            Console.WriteLine("I am {0}", s);
        }
    }
