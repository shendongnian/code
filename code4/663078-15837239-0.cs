    public IEnumerable<MyClass> AncestorsOf(MyClass obj)
    {
       var parent = GetParentObject(obj);
       if (parent != null)
       { 
           yield return parent;
           foreach(var grandparent in AncestorsOf(parent))
              yield return grandparent;
       }
    }
