    static void Main(string[] args) {
        Console.WriteLine("Test");
                
        while (true) {
            WriteBlinkingText("Test", 200);
        }
                
    }
    private static void WriteBlinkingText(string text, int delay) {
       Console.CursorTop--;
       Console.CursorLeft = 0;
       Console.Write(text);
       Console.CursorLeft = 0;
       Console.CursorTop++;
       Thread.Sleep(delay);
       Console.CursorTop--;
       String s = new String(' ', text.Length);
       Console.CursorLeft = 0;
       Console.Write(s);
       Console.CursorLeft = 0;
       Console.CursorTop++;
       Thread.Sleep(delay);
    }
