    public interface IPlaceable
    {
        int Place { get; set; }
    }
    public class Car : IPlaceable
    {
        public int Place { get; set; }
        //Other related fields
    }
    public class Human : IPlaceable
    {
        public int Place { get; set; }
        //Other related fields
    }
    // Somwhere in program
    List<IPlaceable> GameObjects;
    // Somwhere else
    GameObjects.OrderBy(go => go.Place);
