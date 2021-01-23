    static async void Run() {
        object[] result = await new MyClass().FromEvent("Fired");
        Console.WriteLine(string.Join(", ", result.Select(arg =>
            arg.ToString()).ToArray())); // 123, abcd
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
