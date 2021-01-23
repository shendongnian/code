    //My job is to keep score; I don't interpret the scores
    public interface IScoreKeeper : IScoreReporter
    {
        void SetScore(int bowlerIndex, int frameIndex, int throwIndex, int score);
    }
    
    //My job is to report scores to those who want to know the score, but shouldn't be allowed to change it
    public interface IScoreReporter
    {
        int? GetScore(int bowlerIndex, int frameIndex, int throwIndex);        
    }
    //My job is to play the game when told that it's my turn
    public interface IBowler
    {
        //I'm given access to the ScoreReporter at some point, so I can use that to strategize
        //(more realisically, to either gloat or despair as applicable)
        //Throw one ball in the lane, however I choose to do so
        void Bowl(IBowlingLane lane);
    }
    //My job is to keep track of the pins and provide score feedback when they are knocked down
    //I can be reset to allow bowling to continue
    public interface IBowlingLane
    {
        int? GetLastScore();
        void ResetLane();
    }
    //My job is to coordinate a game of bowling with multiple players
    //I tell the Bowlers to Bowl, retrieve scores from the BowlingLane and keep
    //the scores with the ScoreKeeper.
    public interface IBowlingGameCoordinator
    {
        //In reality, I would probably have other service dependencies, like a way to send feedback to a monitor
        //Basically anything that gets too complicated and can be encapsulated, I offload to some other service to deal with it
        //I'm lazy, so all I want to do is tell everybody else what to do.
        void PlayGame(IScoreKeeper gameScore, IEnumerable<IBowler> bowlers, IBowlingLane lane);
    }
