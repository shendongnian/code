    namespace My.Assembly.Namespace
    {
        public class MyImage : Sitecore.Web.UI.WebControls.Image
        {
            public virtual string RelAttribute { get; set; }
            protected override void PopulateParameters(Sitecore.Collections.SafeDictionary<string> parameters)
            {
                base.PopulateParameters(parameters);
                if (!String.IsNullOrEmpty(RelAttribute))
                {
                    parameters.Add("rel", RelAttribute);
                }
            }
        }
    }
