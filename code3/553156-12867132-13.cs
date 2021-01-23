    static async void Run() {
        var result = await TaskFromEvent<int, string>(new MyClass(), "Fired");
        Console.WriteLine(result); // (123, "abcd")
    }
    public class MyClass {
        public delegate void TwoThings(int x, string y);
        public MyClass() {
            new Thread(() => {
                Thread.Sleep(1000);
                Fired(123, "abcd");
            }).Start();
        }
        public event TwoThings Fired;
    }
