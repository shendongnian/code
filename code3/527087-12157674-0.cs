    public interface IPlaceable
    {
        public int Place;
    }
    public class Car : IPlaceable 
    {
        public int Place;
        //Other related fields
    }
    public class Human : IPlaceable 
    {
        public int Place;
        //Other related fields
    }
    // Somwhere in program
    List<IPlaceable> GameObjects;
    // Somwhere else
    GameObjects.OrderBy(go => go.Place);
