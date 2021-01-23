    [ModuleExport("SnakeModule", typeof(IGame))]
    public class SnakeModule : IGame
    {
        public void Initialize()
        {
            Console.WriteLine("test");
        }
        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
