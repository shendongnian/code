    public class GameObject
    {
        public virtual void SetPosition() { ... }
    }
    public class DelegatingGameObject : GameObject
    {
        public GameObject Inner;
        public override void SetPosition() { Inner.SetPosition(); }
    }
    public class Tree : DelegatingGameObject
    {
    }
