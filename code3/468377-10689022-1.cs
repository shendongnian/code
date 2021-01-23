    public class AddXmlNamespace : ..., IComponent
    {
        #region Design-Time Properties
        public String Namespace { get; set; }
        #endregion
        
        #region IComponent Implementation
        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            var stream = new AddXmlNamespaceStream( 
                pInMsg.BodyPart.GetOriginalDataStream()
                , Namespace);
            pInMsg.BodyPart.Data = stream;
            pContext.ResourceTracker.AddResource(stream);
            return pInMsg;
        }
        #endregion
        ...
    }
