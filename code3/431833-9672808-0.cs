    interface IGUIObject 
    {
      Rectangle Bounds { get; }
      Rectangle RectangleToScreen(Rectangle bounds);
      IGUIObject Parent { get; }
    }
    var obj = GetInstance();
    var proxy = Reflection.Coerce<IGUIObject>(obj);
    return proxy.Parent.RectangleToScreen(proxy.Bounds);
