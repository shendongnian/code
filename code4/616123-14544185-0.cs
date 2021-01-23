    public sealed class RestoreHealth : ICommand {
        public int Value { get; set; }
        //whatever else you need
    }
    public sealed class SummonMonster : ICommand {
        public int Count {get; set; }
        public Position Position { get; set; }
    }
