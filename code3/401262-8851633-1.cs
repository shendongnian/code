    public ITransformProvider Transformer
    {
      get{
        //searches up the control hierarchy to find the first ITransformProvider.
        //should be the form, but also allows you to use your own container controls
        //to change within the form.  The algorithm could be improved by caching the
        //result, invalidating it if the control is moved to another container of course.
        var parent = Parent;
        ITransformProvider provider = parent as ITransformProvider;
        while(provider == null){
          parent = parent.Parent;
          provider = parent as ITransformProvider;
        }
        return provider;
      }
    }
