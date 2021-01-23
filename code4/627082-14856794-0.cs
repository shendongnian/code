    var weakRef = new WeakReference(new StringBuilder("Mehran"));
    
    if (weakRef.IsAlive)
    {
        var stringBuilder = weakRef.Target as StringBuilder;
    
        if (stringBuilder != null)
        {
            Console.WriteLine(stringBuilder.ToString());
        }
    }
