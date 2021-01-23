    class App
    {
        private enum ConstantsEnum: int
        {
          DefaultName = 0,
          DefaultMode = 1,
          DefaultStatus = 2
        }
        private readonly string[] Constants = new string[]{
            "MyProgram",
            "Test",
            "Enabled" };
        private void DoWork()
        {
            Console.WriteLine(Constants[ConstantsEnum.DefaultName]);
        }
    }
