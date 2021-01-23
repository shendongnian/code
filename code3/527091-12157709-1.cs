    public interface IGameObject
    {
        int Place { get; }
    }
    public class Car : IGameObject
    {
        public int Place { get; set; }
    }
    public class Human : IGameObject
    {
        public int Place { get; set; }
    }
    List<IGameObject> GameObjects
