    public class DatabaseResourceSet : ResourceSet
    {
        private readonly CultureInfo culture;
        private static readonly Dictionary<string, Hashtable> cachedResources = new Dictionary<string, Hashtable>();
        public DatabaseResourceSet(CultureInfo culture)
        {
            if (culture == null)
                throw new ArgumentNullException("culture");
            this.culture = culture;
            ReadResources();
        }
        protected override void ReadResources()
        {
            if (cachedResources.ContainsKey(culture.Name))
            // retrieve cached resource set
            {
                Table = cachedResources[culture.Name];
                return;
            }
            using (MyDatabaseContext db = new MyDatabaseContext())
            {
                var translations = from t in db.Translations
                           where t.CultureIso == culture.Name
                           select t;
                foreach (var translation in translations)
                {
                    Table.Add(translation.Chave, translation.Valor);
                }
            }
            cachedResources[culture.Name] = Table;
        }
    }
