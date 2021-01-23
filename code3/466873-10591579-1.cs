    public abstract class Player
    {
        public string Name { get; private set; }
        public int Score { get; set; }
        public Player(string name)
        {
            Name = name;
        }
        public abstract void ActAsync(int max);
        public virtual event EventHandler<ActEventArgs> ActComplete;
    }
    public class ActEventArgs : EventArgs
    {
        public int Result { get; private set; }
        public ActEventArgs(int result)
        {
            this.Result = result;
        }
    }
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name)
            : base(name)
        {
        }
        public override void ActAsync(int max)
        {
            // button1 should be the user's guess button; anything else you need to do to allow them to interact should be done here
            button1.IsEnabled = true;
            // this will result in a handler being added each time the user is asked to act; you'll actually want to attach just once
            button1.Click += (s, e) =>
                {
                    button1.IsEnabled = false;
                    if (ActComplete != null)
                        ActComplete(this, new ActEventArgs(int.Parse(data.HumanGuess))); // data.HumanGuess is their input, as a string
                };
        }
        public override event EventHandler<ActEventArgs> ActComplete;
    }
    public class ComputerPlayer : Player
    {
        private readonly Random _random = new Random((int)DateTime.Now.Ticks);
        public ComputerPlayer(string name)
            : base(name)
        {
        }
        public override void ActAsync(int max)
        {
            if (ActComplete != null)
                ActComplete(this, new ActEventArgs(_random.Next(max)));
        }
        public override event EventHandler<ActEventArgs> ActComplete;
    }
