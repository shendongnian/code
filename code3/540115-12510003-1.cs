    public static void ping(int a, string[] arr) {
        for(int i = 0; i < arr.Length; i++) {
             System.Console.Write(a);
             System.Console.Write(arr[i]);
        }
    }
    public static void Main(string[] args) {
        string[] arr = { "a", "b" };
        ping(10, arr);
    }
