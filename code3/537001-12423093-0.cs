    public enum Flags : ushort
    {
       Item = 1,
       Player = 2
    }
    
    public class Item
    {
        public Flags _flags;
        public int _owner;
        public String _pwd;
    
    
    public Item(Flags flags, int owner, String pwd = null)
     {
      _owner=owner;
      _flags=flags;
      _pwd=pwd;
     }
    }
    
    public class Connection
    {
        public Connection()
        {
        }
    }
    public class Player : Item
    {
        public Connection Conn;
        public Player(Item i) : base(i._flags,i._owner,i._pwd)
        {
            // and add your "additional thing"
            // This calls the base constructor, and then you can add codes...
        }
    
    }
