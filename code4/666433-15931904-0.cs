    public interface IModel
    {
        void Update();
    }
    public class MyModelA : IModel
    {
        public void Update() { ... }
    }
    public class MyModelB : IModel 
    {
        public void Update() { ... }
    }
