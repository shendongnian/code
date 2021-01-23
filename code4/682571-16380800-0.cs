    Dictionary<Type, object> MyEventsByType;
    event Action<A> CollisionEventA;
    event Action<B> CollisionEventB;
    event Action<C> COllisionEventC;
    void Initialize()
    {
        MyEventsByType = new Dictionary<Type, object>();
        MyEventsByType.Add(typeof(A), CollisionEventA);
        MyEventsByType.Add(typeof(B), CollisionEventB);
        MyEventsByType.Add(typeof(C), CollisionEventC);
    }
    void RaiseCollision<T>(T Obj)
    {
        Action<T> Event = (Action<T>)MyEventsByType[typeof(T)];
        if (Event != null) Event(Obj);
    }
