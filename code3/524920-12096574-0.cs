    if(this is ITestClass)
        return this.GetTheType<ITestClass>();
    else if(this is INotTestClass)
        return this.GetTheType<INotTestClass>();
    else 
        throw new InvalidOperationException // or whatever
                    ("unexpected type: " + this.GetType());
