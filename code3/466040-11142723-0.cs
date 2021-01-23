    public override TouchPointCollection GetIntermediateTouchPoints(System.Windows.IInputElement relativeTo)
    {
        TouchPointCollection refCollection = new TouchPointCollection();
        refCollection.Add(TouchPointCollection(relativeTo));
        return refCollection;
    }
