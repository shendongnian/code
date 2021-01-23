    class SpecialGameObject : GameObject
    {
        public override void SetPosition()
        {
            if (isMonday) base.SetPosition();
        }
    }
    var tree = new Tree { Inner = new SpecialGameObject() };
    tree.SetPosition();
