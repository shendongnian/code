    public class MyTest {
        private Func<IMyContext> createContext;
        public MyTest(Func<IMyContext> createContext){
           this.createContext = createContext;
        }
     
        [Test]
        public void RunTest(){
            using(var context = this.createContext()){
                 // do stuff with context
            }
        }
    }
