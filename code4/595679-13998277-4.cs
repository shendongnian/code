    class Program
    {
        static void Main(string[] args)
        {
            KeyboardHook.CreateHook();
            KeyboardHook.KeyPressed += KeyboardHook_KeyPressed;
            Application.Run();
            KeyboardHook.DisposeHook();
        }
        static void KeyboardHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Console.WriteLine(e.KeyCode.ToString());
        }
    }
