    public static String RenderEditData<T>() where T : CorinaEntity
    {
        string id = new IdGenerator().Generate<T>();
   
        return new HtmlString(
               string.Format("data-corina='{{ id : \'{0}\', 'clrType' : \'{1}\' }}", 
                                            id, 
                                            typeof(T).AssemblyQualifiedName));
    }
