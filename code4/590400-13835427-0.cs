    var t = someClass.GetType()
    Type[] typeParameters = t.GetGenericArguments();
    if (!typeParameters[0].IsSubclassOf(typeof(someInterface)) || 
        !typeParameters[1].IsSubclassOf(typeof(anotherInterface)))
    {
        return;
    }
