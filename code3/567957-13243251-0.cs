    public class MathClass {
        public Action FunctionToCall { get; set; }
        public void DoSomeMathOperation() {
            // do something here.. then call the function:
            
            FunctionToCall();
        }
    }
