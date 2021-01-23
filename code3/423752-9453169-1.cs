    public class PushGame : ManiaGame
    {
        private readonly PlayState gamePlayState;
        public PushGame() : base()
        {
            gamePlayState = new PlayState(this);
        }
        protected override State GamePlayState
        {
            get { return gamePlayState; }
        }
    }
    public abstract class ManiaGame
    {
        protected abstract State GamePlayState { get; }
    }
    public class State
    {
        public State(ManiaGame mg) { }
    }
    public class PlayState : State
    {
        public PlayState(ManiaGame mg) : base(mg) { }
    }
