    public interface IBall
    {
    }
    public class BilliardBall : IBall
    {
    }
    public abstract class Sport
    {
        protected abstract IBall Ball { get; }
    }
    public class Billiards : Sport
    {
        protected override IBall Ball
        {
            get { return new BilliardBall(); }
        }
    }
