    public ClassB
    {
         public void UpdateAndBind(Func<ClassA, bool> getProp, Func<ClassA, bool, ClassA> setProp)
        {
            ClassA c = GetCurrentClassA();
            // What to do here to set the property?
            setProp(c, getProp(c));
            ClassADataAccess.Update(c);
            this.BindClassADetails(c);
        }
        ...
    }
