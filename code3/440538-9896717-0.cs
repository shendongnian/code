    interface IXmlTransformer
    { 
       string Transform(object entity);
    }
    class EntityAXmlTransformer : IXmlTransformer
    {
        string Transform(object entity) { /* implementation */ }
    }
    class EntityBXmlTransformer : IXmlTransformer
    {
        string Transform(object entity) { /* implementation */ }
    }
    // ideally an IoC container would do this - but here is a naive factory implementation
    class XmlTransformerFactory
    {
         private static readonly Dictionary<Type, IXmlTransformer> transformers = new Dictionary<Type, IXmlTransformer>
         {
              { typeof(EntityA), new EntityAXmlTransformer() },
              { typeof(EntityB), new EntityBXmlTransformer() }
         }
         public IXmlTransformer Get<T>()  // could be static
         {
             IXmlTransformer transformer;
             if (!transformers.TryGetValue(typeof(T), out transformer))
             {
                 return null;
             }
             return transformer;
         }
    }
