    class GameObject
    {
        public virtual void SetPosition() { ... }
    }
    class DelegatingGameObject
    {
        public GameObject Inner;
        public override void SetPosition() { Inner.SetPosition(); }
    }
    class Tree : DelegatingGameObject
    {
    }
