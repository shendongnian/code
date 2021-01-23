    public class TestEventInvocationList {
        public static void ShowEventInvocationList() {
            var testEventInvocationList = new TestEventInvocationList();
            testEventInvocationList.MyEvent += testEventInvocationList.MyInstanceEventHandler;
            testEventInvocationList.MyEvent += MyNamedEventHandler;
            testEventInvocationList.MyEvent += (s, e) => {
                // Lambda expression method
            };
    
            testEventInvocationList.DisplayEventInvocationList();
            Console.ReadLine();
        }
    
        public static void MyNamedEventHandler(object sender, EventArgs e) {
            // Static eventhandler
        }
    
        public event EventHandler MyEvent;
    
        public void DisplayEventInvocationList() {
            if (MyEvent != null) {
                foreach (Delegate d in MyEvent.GetInvocationList()) {
                    Console.WriteLine("Object: {0}, Method: {1}", (d.Target ?? "null").ToString(), d.Method);
                }
            }
        }
    
        public void MyInstanceEventHandler(object sendef, EventArgs e) {
            // Instance event handler
        }
    }
