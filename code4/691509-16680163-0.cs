    public class ArtifyModelMetaDataProvider : DataAnnotationsModelMetadataProvider
    {
        private static List<Tuple<FieldInfo, FieldInfo>> _fieldsMap;
        private static ArtifyModelMetaDataProvider()
        {
            foreach (FieldInfo customFI in typeof(ArtifyModelMetadata).GetFields())
                foreach (FieldInfo baseFI in typeof(DataAnnotationsModelMetadata).GetFields())
                    if (customFI.Name == baseFI.Name)
                        _fieldsMap.Add(new Tuple<FieldInfo, FieldInfo>(customFI, baseFI));
        }
        private static void CopyToCustomMetadata(ModelMetadata baseMetadata, ArtifyModelMetadata customMetadata)
        {
            foreach (Tuple<FieldInfo, FieldInfo> t in _fieldsMap)
                t.Item1.SetValue(customMetadata, t.Item2.GetValue(baseMetadata));
        }
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ArtifyModelMetadata modelMetadata = new ArtifyModelMetadata(this, containerType, modelAccessor, modelType, propertyName);
            CopyToCustomMetadata(base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName), modelMetadata);
            
            ModelMetadataAttribute mma;
            Dictionary<string, string> htmlAttributes;
            object tmp;
            foreach (Attribute a in attributes)
            {
                mma = a as ModelMetadataAttribute;
                if (mma != null)
                {
                    mma.Process(modelMetadata);
                    htmlAttributes = mma.GetAdditionnalHtmlAttributes();
                    if (htmlAttributes != null)
                    {
                        foreach (KeyValuePair<string, string> p in htmlAttributes)
                        {
                            tmp = null;
                            tmp = modelMetadata.AdditionnalHtmlAttributes.TryGetValue(p.Key, out tmp);
                            if (tmp == null)
                                modelMetadata.AdditionnalHtmlAttributes.Add(p.Key, p.Value);
                            else
                                modelMetadata.AdditionnalHtmlAttributes[p.Key] = tmp.ToString() + " " + p.Value;
                        }
                    }
                }
                if (mma is TooltipAttribute)
                    modelMetadata.HasToolTip = true;
            }
            
            return modelMetadata;
        }
    }
    public class ArtifyModelMetadata : DataAnnotationsModelMetadata
    {
        public bool HasToolTip { get; internal set; }
        public Dictionary<string, object> AdditionnalHtmlAttributes { get; private set; }
        public ArtifyModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
            : base(provider, containerType, modelAccessor, modelType, propertyName, null)
        {
            AdditionnalHtmlAttributes = new Dictionary<string, object>();
        }
    }
