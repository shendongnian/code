    public class SessionMetadata
    {
        private static readonly Type KeyType = typeof(ActiveRecordBase);
        private ISessionFactoryHolder _sessionFactoryHolder;
        private ISessionFactory _sessionFactory;
        private ISessionFactoryImplementor _sessionFactoryImplementor;
        private Configuration _configuration;
        private ISession _currentSession;
        private ISessionImplementor _sessionImplementor;
        private DriverBase _driver;
        private NonBatchingBatcher _batcher;
        private IMapping _mapping;
        public ISessionFactoryHolder SessionFactoryHolder
        {
            get { return _sessionFactoryHolder ?? (_sessionFactoryHolder = ActiveRecordMediator.GetSessionFactoryHolder()); }
        }
        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = SessionFactoryHolder.GetSessionFactory(KeyType)); }
        }
        public ISessionFactoryImplementor SessionFactoryImplementor
        {
            get { return _sessionFactoryImplementor ?? (_sessionFactoryImplementor = (ISessionFactoryImplementor)SessionFactory); }
        }
        public DriverBase Driver
        {
            get { return _driver ?? (_driver = (DriverBase)SessionFactoryImplementor.ConnectionProvider.Driver); }
        }
        public NonBatchingBatcher Batcher
        {
            get { return _batcher ?? (_batcher = (NonBatchingBatcher)SessionImplementor.Batcher); }
        }
        public Configuration Configuration
        {
            get { return _configuration ?? (_configuration = SessionFactoryHolder.GetConfiguration(KeyType)); }
        }
        public ISession CurrentSession
        {
            get { return _currentSession ?? (_currentSession = SessionScope.Current.GetSession(SessionFactory)); }
        }
        public ISessionImplementor SessionImplementor
        {
            get { return _sessionImplementor ?? (_sessionImplementor = CurrentSession.GetSessionImplementation()); }
        }
        public IMapping Mapping
        {
            get { return _mapping ?? (_mapping = SessionFactoryImplementor); }
        }
    }
    
    public class EntityMetadata
    {
        private readonly SessionMetadata _sessionMetadata;
        private readonly Type _entityType;
        private PersistentClass _persistentClass;
        private IEntityPersister _entityPersister;
        public EntityMetadata(Type entityType, SessionMetadata sessionMetadata)
        {
            _sessionMetadata = sessionMetadata;
            _entityType = entityType;
        }
        public SessionMetadata SessionMetadata
        {
            get { return _sessionMetadata; }
        }
        public PersistentClass PersistentClass
        {
            get { return _persistentClass ?? (_persistentClass = SessionMetadata.Configuration.GetClassMapping(_entityType)); }
        }
        public IEntityPersister EntityPersister
        {
            get { return _entityPersister ?? (_entityPersister = SessionMetadata.SessionFactoryImplementor.GetEntityPersister(PersistentClass.EntityName)); }
        }
    }
    public class ExtractSql: SingleTableEntityPersister
    {
        private readonly SessionMetadata _sessionMetadata;
        private readonly EntityMetadata _entityMetadata;
        private readonly IEntityPersister _entityPersister;
        private readonly bool[][] _propertyColumnInsertable;
        private readonly bool[][] _propertyColumnUpdateable;
        public ExtractSql(EntityMetadata entityMetadata)
            : base(entityMetadata.PersistentClass, null, entityMetadata.SessionMetadata.SessionFactoryImplementor, entityMetadata.SessionMetadata.Mapping)
        {
            if (entityMetadata == null) throw new ArgumentNullException("entityMetadata");
            _sessionMetadata = entityMetadata.SessionMetadata;
            _entityMetadata = entityMetadata;
            _entityPersister = _entityMetadata.EntityPersister;
            var hydrateSpan = _entityPersister.EntityMetamodel.PropertySpan;
            _propertyColumnUpdateable = new bool[hydrateSpan][];
            _propertyColumnInsertable = new bool[hydrateSpan][];
            var i = 0;
            foreach (var prop in _entityMetadata.PersistentClass.PropertyClosureIterator)
            {
                _propertyColumnInsertable[i] = prop.Value.ColumnInsertability;
                _propertyColumnUpdateable[i] = prop.Value.ColumnUpdateability;
                i++;
            }
        }
        protected override bool UseDynamicUpdate
        {
            get { return true; }
        }
        protected override bool UseDynamicInsert
        {
            get { return true; }
        }
        public IDbCommand CreateInsertCommand(object entity)
        {
            var entityTuplizer = GetTuplizer(_sessionMetadata.SessionImplementor);
            var values = entityTuplizer.GetPropertyValuesToInsert(entity, new Dictionary<object, object>(), _sessionMetadata.SessionImplementor);
            var notNull = GetPropertiesToInsert(values);
            var sql = GenerateInsertString(true, notNull);
            var insertCommand = _sessionMetadata.Batcher.Generate(sql.CommandType, sql.Text, sql.ParameterTypes);
            Dehydrate(null, values, notNull, _propertyColumnInsertable, 0, insertCommand, _sessionMetadata.SessionImplementor);
            InfraUtil.FixupGuessedType(insertCommand);
            return insertCommand;
        }
    }
