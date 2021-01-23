    public class XmlRepository : IRepository<Configuration>
    {
        private readonly List<Configuration> configurations;
    
        public XmlRepository(string filename)
        {
            FileName = filename;
    
            XmlSerializer serializer = new XmlSerializer(typeof(List<Configuration>), null, new Type[] { typeof(BinaryConfiguration) }, new XmlRootAttribute("Configurations"), "http://ofimbres.wordpress.com/");
            using (StreamReader myWriter = new StreamReader(FileName))
            {
                configurations = (List<Configuration>)serializer.Deserialize(myWriter);
                myWriter.Close();
            }
        }
    
        internal string FileName { get; private set; }
    
        public Configuration GetById(object id)
        {
            return (from c in configurations where c.Id == id select c).Single();
        }
    
        public IEnumerable<Configuration> All()
        {
            return configurations;
        }
    
        public void Insert(Configuration entity)
        {
            configurations.Add(entity);
        }
    
        public void Remove(Configuration entity)
        {
            configurations.Remove(entity);
        }
    
        public void SaveChanges()
        {
            XmlSerializer serializer = new XmlSerializer(configurations.GetType(), null, new Type[] { typeof(BinaryConfiguration) }, new XmlRootAttribute("Configurations"), "http://ofimbres.wordpress.com/");
            using (StreamWriter myWriter = new StreamWriter(FileName))
            {
                serializer.Serialize(myWriter, configurations);
                myWriter.Close();
            }
        }
    }
