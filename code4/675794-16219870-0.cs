    public interface IMinimalState
    {
        IMinimalState generate();
        int getData();
    }
    public interface IState : IMinimalState
    {
        // IState generate();
        int getAnotherData();
    }
    public class MinimalState : IMinimalState
    {
        public IMinimalState generate() { return this; }
        public int getData() { return 0; }
    }
    public class State : IState
    {
        IMinimalState IMinimalState.generate() { return this.generate(); }
        // IState IState.generate() { return this; }
        public IState generate() { return this; }
        public int getData() { return 1; }
        public int getAnotherData() { return 2; }
    }
