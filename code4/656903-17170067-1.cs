    class CollisionResolver
    {
        Dictionary<Tuple<CollisionGroup, CollisionGroup>, Action<ICollider, ICollider>> lookup
            = new Dictionary<Tuple<CollisionGroup, CollisionGroup>, Action<ICollider, ICollider>>();
        public void Register(CollisionGroup a, CollisionGroup b, Action<ICollider, ICollider> action)
        {
            lookup[Tuple.Create(a, b)] = action;
        }
        public void Resolve(ICollider a, ICollider b)
        {
            Action<ICollider, ICollider> action;
            if (!lookup.TryGetValue(Tuple.Create(a.Group, b.Group), out action))
                action = (c1, c2) => Console.WriteLine("Nothing happened..!");
            action(a, b);
        }
    }
