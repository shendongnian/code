    public interface IComponent{
        string Name{get;}
        IEnumerable<IComponent> Childrens{get;}
    }
    public class Group : IComponent{
        private List<User> _users;
        ---
        IEnumerable<IComponent> Childerns{ get{ return _users;}}
    }
    public class User : IComponent {
        private List<Demo> _demos;
        private List<Live> _lives;
        IEnumerable<IComponent> Childresn { get { return _demos.Cast<IComponent>().Union(_lives.Cast<IComponent>()); }}
    }
    public class Demo : IComponent{..}
    public class Live : IComponent {..}
