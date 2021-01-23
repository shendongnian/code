    public class MappingParameter<TSource>
    {
        private readonly Delegate setter;
        private MappingParameter(Delegate compiledSetter)
        {
            setter = compiledSetter;
        }
        public static MappingParameter<TSource> Create<TResult>(Expression<Func<TSource, TResult>> expression)
        {
            var newValue = Expression.Parameter(expression.Body.Type);
            var body = Expression.Assign(expression.Body, newValue);
            var assign = Expression.Lambda(body, expression.Parameters[0], newValue);
            var compiledSetter = assign.Compile();
            return new MappingParameter<TSource>(compiledSetter);
        }
        public void Assign(TSource instance, object value)
        {
            object convertedValue;
            if (!setter.Method.ReturnType.IsAssignableFrom(typeof(string)))
            {
                convertedValue = Convert.ChangeType(value, setter.Method.ReturnType);
            }
            else
            {
                convertedValue = value;
            }
            setter.DynamicInvoke(instance, convertedValue);
        }
    }
    public class DataRowMappingConfiguration<TSource>
    {
        private readonly Dictionary<string, MappingParameter<TSource>> mappings =
            new Dictionary<string, MappingParameter<TSource>>();
        public DataRowMappingConfiguration<TSource> Add<TResult>(string columnName,
                                                                 Expression<Func<TSource, TResult>> expression)
        {
            mappings.Add(columnName, MappingParameter<TSource>.Create(expression));
            return this;
        }
        public Dictionary<string, MappingParameter<TSource>> Mappings
        {
            get
            {
                return mappings;
            }
        }
    }
    public class DataRowMapper<TSource>
    {
        private readonly DataRowMappingConfiguration<TSource> configuration;
        public DataRowMapper(DataRowMappingConfiguration<TSource> configuration)
        {
            this.configuration = configuration;
        }
        public IEnumerable<TSource> Map(DataTable table)
        {
            var list = new List<TSource>(table.Rows.Count);
            foreach (DataRow dataRow in table.Rows)
            {
                var obj = (TSource)Activator.CreateInstance(typeof(TSource));
                foreach (var mapping in configuration.Mappings)
                {
                    mapping.Value.Assign(obj, dataRow[mapping.Key]);
                }
                list.Add(obj);
            }
            return list;
        }
    }
    public class TestClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    [TestFixture]
    public class DataRowMappingTests
    {      
        [Test]
        public void ShouldMapPropertiesUsingOwnMapper()
        {            
            var mappingConfiguration = new DataRowMappingConfiguration<TestClass>()
                .Add("firstName", x => x.Name)
                .Add("age", x => x.Age);
            
            var mapper = new DataRowMapper<TestClass>(mappingConfiguration);                      
            var dataTable = new DataTable();
            dataTable.Columns.Add("firstName");
            dataTable.Columns.Add("age");
            for (int i = 0; i < 5000000; i++)
            {
                var row = dataTable.NewRow();
                row["firstName"] = "John";
                row["age"] = 15;
                dataTable.Rows.Add(row);                
            }
            var start = DateTime.Now;
            var result = mapper.Map(dataTable).ToList();
            Console.WriteLine((DateTime.Now - start).TotalSeconds);
            Assert.AreEqual("John", result.First().Name);
            Assert.AreEqual(15, result.First().Age);
        }
        [Test]
        public void ShouldMapPropertyUsingAutoMapper()
        {
            Mapper.CreateMap<DataRow, TestClass>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y["firstName"]))
                .ForMember(x => x.Age, x => x.MapFrom(y => y["age"]));
            var dataTable = new DataTable();
            dataTable.Columns.Add("firstName");
            dataTable.Columns.Add("age");
            for (int i = 0; i < 5000000; i++)
            {
                var row = dataTable.NewRow();
                row["firstName"] = "John";
                row["age"] = 15;
                dataTable.Rows.Add(row);
            }
            var start = DateTime.Now;
            var result = dataTable.Rows.OfType<DataRow>().Select(Mapper.Map<DataRow, TestClass>).ToList();         
            Console.WriteLine((DateTime.Now - start).TotalSeconds);
            Assert.AreEqual("John", result.First().Name);
            Assert.AreEqual(15, result.First().Age);
        }
    }
