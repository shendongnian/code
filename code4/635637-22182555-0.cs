    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Core.Mapping;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Reflection;
    using System.Xml;
    
    namespace WS.Framework.WSJDEData
    {
    
        public partial class WSJDE : DbContext
        {
            public WSJDE()
                : base("name=WSJDE")
            {
                ObjectContext context = (this as IObjectContextAdapter).ObjectContext;
    
                string environment = ConfigurationManager.AppSettings.Get("Environment");
    
                const string devCTL = "TESTCTL";
                const string devDTA = "TESTDTA";
                const string qaCTL = "CRPCTL";
                const string qaDTA = "CRPDTA";
                const string prodCTL = "PRODCTL";
                const string prodDTA = "PRODDTA";
    
                var x = Assembly.GetExecutingAssembly().GetManifestResourceStream("WSJDEData.WSJDE.ssdl");
    
                XmlReader[] sReaders = new XmlReader[]
                    {
                        XmlReader.Create(Assembly.GetExecutingAssembly().GetManifestResourceStream("WSJDEData.WSJDE.ssdl"))
                    };
    
                XmlReader[] mReaders = new XmlReader[]
                    {XmlReader.Create(Assembly.GetExecutingAssembly().GetManifestResourceStream("WSJDEData.WSJDE.msl"))};
    
                StoreItemCollection sCollection = new StoreItemCollection(sReaders);
    
                ObjectContext objContext = ((IObjectContextAdapter) context).ObjectContext;
                MetadataWorkspace workspace = objContext.MetadataWorkspace;
    
                EdmItemCollection cCollection = workspace.GetItemCollection(DataSpace.CSpace) as EdmItemCollection;
    
    
                StorageMappingItemCollection csCollection = new StorageMappingItemCollection(cCollection, sCollection,
                                                                                             mReaders);
    
                workspace.RegisterItemCollection(sCollection);
                workspace.RegisterItemCollection(csCollection);
    
                EntityContainer container = workspace.GetItem<EntityContainer>("WSJDEModelStoreContainer", DataSpace.SSpace);
    
                foreach (EntitySetBase entitySetBase in container.BaseEntitySets)
                {
                    string schema = entitySetBase.Schema;
    
                    if (schema != null)
                    {
                        string name = schema.Substring(schema.Length - 3);
    
                        if (name == "CTL")
                        {
                            switch (environment)
                            {
                                case "Dev":
                                    typeof (EntitySetBase).GetField("_schema",
                                                                    BindingFlags.NonPublic | BindingFlags.Instance)
                                                          .SetValue(entitySetBase, devCTL);
                                    break;
                                case "QA":
                                    typeof (EntitySetBase).GetField("_schema",
                                                                    BindingFlags.NonPublic | BindingFlags.Instance)
                                                          .SetValue(entitySetBase, qaCTL);
                                    break;
                                case "Prod":
                                    typeof (EntitySetBase).GetField("_schema",
                                                                    BindingFlags.NonPublic | BindingFlags.Instance)
                                                          .SetValue(entitySetBase, prodCTL);
                                    break;
    
                            }
                        }
    
                        if (name == "DTA")
                        {
                            switch (environment)
                            {
                                case "Dev":
                                    typeof (EntitySetBase).GetField("_schema",
                                                                    BindingFlags.NonPublic | BindingFlags.Instance)
                                                          .SetValue(entitySetBase, devDTA);
                                    break;
                                case "QA":
                                    typeof (EntitySetBase).GetField("_schema",
                                                                    BindingFlags.NonPublic | BindingFlags.Instance)
                                                          .SetValue(entitySetBase, qaDTA);
                                    break;
                                case "Prod":
                                    typeof (EntitySetBase).GetField("_schema",
                                                                    BindingFlags.NonPublic | BindingFlags.Instance)
                                                          .SetValue(entitySetBase, prodDTA);
                                    break;
    
                            }
                        }
                    }
                }
            }
        }
    }
