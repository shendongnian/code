    public class GameObject
    {
        public virtual void SetPosition() { Console.WriteLine("GameObject.SetPosition"); }
        public static event Func<GameObject> Factory;
        internal static GameObject CreateBase() { var factory = Factory; return (factory != null) ? factory() : new GameObject(); }
    }
    internal class GameObjectBase : GameObject
    {
        private readonly GameObject baseGameObject;
        protected GameObjectBase() { baseGameObject = GameObject.CreateBase(); }
        public override void SetPosition() { baseGameObject.SetPosition(); }
    }
    internal class Tree : GameObjectBase
    {
        public override void SetPosition()
        {
            Console.WriteLine("Tree.SetPosition");
            base.SetPosition();
        }
    }
    public static class Game
    {
        public static void Start()
        {
            new Tree().SetPosition();
        }
    }
