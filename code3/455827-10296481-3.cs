    class ClientGameObject : GameObject
    {
        public override void SetPosition()
        {
            if (isMonday) base.SetPosition();
        }
    }
    var tree = new Tree { Inner = new ClientGameObject() };
    tree.SetPosition();
