    using Sitecore.Data.DataProviders;
    using Sitecore.Data;
    using Sitecore.StringExtensions;
    
    namespace Example
    {
        public class CloneStyleDataProvider : DataProvider
        {
            public string Style { get; set; }
    
            public override Sitecore.Data.FieldList GetItemFields(Sitecore.Data.ItemDefinition itemDefinition, Sitecore.Data.VersionUri versionUri, CallContext context)
            {
                var fields = context.CurrentResult as FieldList;
                if (fields == null || fields[Sitecore.FieldIDs.Source].IsNullOrEmpty() || !fields[Sitecore.FieldIDs.Style].IsNullOrEmpty())
                {
                    return null;
                }
                var newFields = new FieldList();
                newFields.Add(Sitecore.FieldIDs.Style, Style);
                return newFields;
            }
        }
    }
