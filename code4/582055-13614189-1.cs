    public interface IHealth { int Health { get; set; } }
    // Change to a property
    public class Ogre : IHealth { public int Health { get; set; } }
    // Casing is different, so interface can be implemented implicitly
    public class Player : IHealth {
        int health;
        public int Health { get { return health; } set { health = value; } }
    }
    // Name collision with Pascal casing, so implement explicitly
    public class Robot : IHealth {
        int Health;
        int IHealth.Health { get { return Health; } set { Health = value; } }
    }
    
    // Later
    GameObject obj;
    var o = obj.GetComponent<IHealth>();
    if (o != null) o.Health--;
