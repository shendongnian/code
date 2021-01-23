    [DataServiceKey("PartitionKey", "RowKey")]   
    public class GenericEntity   
    {   
        public string PartitionKey { get; set; }   
        public string RowKey { get; set; } 
        Dictionary<string, object> properties = new Dictionary<string, object>();   
  
        internal object this[string key]   
        {   
            get   
            {   
                return this.properties[key];   
            }   
  
            set   
            {   
                this.properties[key] = value;   
            }   
        }   
  
        public override string ToString()   
        {   
            // TODO: append each property   
            return "";   
        }   
    }   
  
        void TestGenericTable()   
        {   
            var ctx = CustomerDataContext.GetDataServiceContext();   
            ctx.IgnoreMissingProperties = true;   
            ctx.ReadingEntity += new EventHandler<ReadingWritingEntityEventArgs>(OnReadingEntity);   
            var customers = from o in ctx.CreateQuery<GenericTable>(CustomerDataContext.CustomersTableName) select o;   
  
            Console.WriteLine("Rows from '{0}'", CustomerDataContext.CustomersTableName);   
            foreach (GenericEntity entity in customers)   
            {   
                Console.WriteLine(entity.ToString());   
            }   
        }  
        // Credit goes to Pablo from ADO.NET Data Service team 
        public void OnReadingEntity(object sender, ReadingWritingEntityEventArgs args)   
        {   
            // TODO: Make these statics   
            XNamespace AtomNamespace = "http://www.w3.org/2005/Atom";   
            XNamespace AstoriaDataNamespace = "http://schemas.microsoft.com/ado/2007/08/dataservices";   
            XNamespace AstoriaMetadataNamespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";   
  
            GenericEntity entity = args.Entity as GenericEntity;   
            if (entity == null)   
            {   
                return;   
            }   
  
            // read each property, type and value in the payload   
            var properties = args.Entity.GetType().GetProperties();   
            var q = from p in args.Data.Element(AtomNamespace + "content")   
                                    .Element(AstoriaMetadataNamespace + "properties")   
                                    .Elements()   
                    where properties.All(pp => pp.Name != p.Name.LocalName)   
                    select new   
                    {   
                        Name = p.Name.LocalName,   
                        IsNull = string.Equals("true", p.Attribute(AstoriaMetadataNamespace + "null") == null ? null : p.Attribute(AstoriaMetadataNamespace + "null").Value, StringComparison.OrdinalIgnoreCase),   
                        TypeName = p.Attribute(AstoriaMetadataNamespace + "type") == null ? null : p.Attribute(AstoriaMetadataNamespace + "type").Value,   
                        p.Value   
                    };   
  
            foreach (var dp in q)   
            {   
                entity[dp.Name] = GetTypedEdmValue(dp.TypeName, dp.Value, dp.IsNull);   
            }   
        }   
  
  
        private static object GetTypedEdmValue(string type, string value, bool isnull)   
        {   
            if (isnull) return null;   
  
            if (string.IsNullOrEmpty(type)) return value;   
  
            switch (type)   
            {   
                case "Edm.String": return value;   
                case "Edm.Byte": return Convert.ChangeType(value, typeof(byte));   
                case "Edm.SByte": return Convert.ChangeType(value, typeof(sbyte));   
                case "Edm.Int16": return Convert.ChangeType(value, typeof(short));   
                case "Edm.Int32": return Convert.ChangeType(value, typeof(int));   
                case "Edm.Int64": return Convert.ChangeType(value, typeof(long));   
                case "Edm.Double": return Convert.ChangeType(value, typeof(double));   
                case "Edm.Single": return Convert.ChangeType(value, typeof(float));   
                case "Edm.Boolean": return Convert.ChangeType(value, typeof(bool));   
                case "Edm.Decimal": return Convert.ChangeType(value, typeof(decimal));   
                case "Edm.DateTime": return XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.RoundtripKind);   
                case "Edm.Binary": return Convert.FromBase64String(value);   
                case "Edm.Guid": return new Guid(value);   
  
                default: throw new NotSupportedException("Not supported type " + type);   
            }   
        }
