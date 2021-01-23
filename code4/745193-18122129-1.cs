    public override bool Equals(object obj)
    {
         return Equals(obj as MyObj);
    }
    public bool Equals(MyObj obj)
    {
         if(ReferenceEquals(obj, null))
             return false;
         // ToDo: further checks for equality.
    }
