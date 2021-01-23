    public class CustomDataContext : DataContext
    {
        static CustomMappingSource _sharedMappingSource = new CustomMappingSource();
        public static void UpdateCustomTable(Type rowType, string tableName)
        {
            _sharedMappingSource.UpdateCustomTable(rowType, tableName);
        }
        public CustomDataContext(System.Data.IDbConnection connection) : base(connection, _sharedMappingSource) { }
        public CustomDataContext(string fileOrServerOrConnection) : base(fileOrServerOrConnection, _sharedMappingSource) { }
    }
    internal class CustomMappingSource : MappingSource
    {
        AttributeMappingSource mapping = new AttributeMappingSource();
        Dictionary<Type, string> _customTableNames = new Dictionary<Type, string>();
        public void UpdateCustomTable(Type rowType, string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("TableName");
            _customTableNames[rowType] = tableName;
        }
        protected override MetaModel CreateModel(Type dataContextType)
        {
            MetaModel oldmodel = mapping.GetModel(dataContextType);
            CustomMetaModel newmodel = new CustomMetaModel(oldmodel, _customTableNames);
            return newmodel;
        }
    }
    internal class CustomMetaModel : MetaModel
    {
        MetaModel _orgmodel;
        Dictionary<Type, MetaTable> _customtables = new Dictionary<Type, MetaTable>();
        Dictionary<Type, MetaType> _customtypes = new Dictionary<Type, MetaType>();
        Dictionary<Type, string> _tableNames = new Dictionary<Type, string>();
        public CustomMetaModel(MetaModel orgmodel, Dictionary<Type, string> tableNames)
        {
            _orgmodel = orgmodel;
            _tableNames = tableNames;
        }
        public override MetaType GetMetaType(Type type)
        {
            if (_customtypes.ContainsKey(type))
                return _customtypes[type];
            else
                return _orgmodel.GetMetaType(type);
        }
        public override MetaTable GetTable(Type rowType)
        {
            if (_customtables.ContainsKey(rowType))
                return _customtables[rowType];
            if (_tableNames.ContainsKey(rowType))
            {
                MetaTable orgtable = _orgmodel.GetTable(rowType);
                MetaType orgrowtype = orgtable.RowType;
                CustomMetaType newRowType = new CustomMetaType(orgrowtype, this);
                _customtables.Add(rowType, new CustomMetaTable(orgtable, this, newRowType, _tableNames[rowType]));
                newRowType.MetaTable = _customtables[rowType];
                return newRowType.MetaTable;
            }
            return _orgmodel.GetTable(rowType);
        }
        #region MetaModel Forwards
        public override Type ContextType { get { return _orgmodel.ContextType; } }
        public override string DatabaseName { get { return _orgmodel.DatabaseName; } }
        public override MappingSource MappingSource { get { return _orgmodel.MappingSource; } }
        public override Type ProviderType { get { return _orgmodel.ProviderType; } }
        public override MetaFunction GetFunction(System.Reflection.MethodInfo method) { return _orgmodel.GetFunction(method); }
        public override IEnumerable<MetaFunction> GetFunctions() { return _orgmodel.GetFunctions(); }
        public override IEnumerable<MetaTable> GetTables() { return _orgmodel.GetTables(); }
        #endregion
    }
    internal class CustomMetaTable : MetaTable
    {
        MetaTable _orgtable;
        MetaModel _metamodel;
        MetaType _rowtype;
        string _tableName;
        public CustomMetaTable(MetaTable orgtable, MetaModel metamodel, MetaType rowtype, string tableName)
        {
            _orgtable = orgtable;
            _metamodel = metamodel;
            _rowtype = rowtype;
            _tableName = tableName;
        }
        public override MetaModel Model { get { return _metamodel; } }
        public override MetaType RowType { get { return _rowtype; } }
        public override string TableName { get { return _tableName; } }
        #region MetaTable Forwards
        public override System.Reflection.MethodInfo DeleteMethod { get { return _orgtable.DeleteMethod; } }
        public override System.Reflection.MethodInfo InsertMethod { get { return _orgtable.InsertMethod; } }
        public override System.Reflection.MethodInfo UpdateMethod { get { return _orgtable.UpdateMethod; } }
        #endregion
    }
    internal class CustomMetaType : MetaType
    {
        MetaType _orgtype;
        MetaModel _metamodel;
        public MetaTable MetaTable { get; set; }
        public CustomMetaType(MetaType orgtype, MetaModel metamodel)
        {
            _orgtype = orgtype;
            _metamodel = metamodel;
        }
        public override MetaTable Table { get { return MetaTable; } }
        public override MetaModel Model { get { return _metamodel; } }
        #region MetaType Forwards
        public override System.Collections.ObjectModel.ReadOnlyCollection<MetaAssociation> Associations { get { return _orgtype.Associations; } }
        public override bool CanInstantiate { get { return _orgtype.CanInstantiate; } }
        public override System.Collections.ObjectModel.ReadOnlyCollection<MetaDataMember> DataMembers { get { return _orgtype.DataMembers; } }
        public override MetaDataMember DBGeneratedIdentityMember { get { return _orgtype.DBGeneratedIdentityMember; } }
        public override System.Collections.ObjectModel.ReadOnlyCollection<MetaType> DerivedTypes { get { return _orgtype.DerivedTypes; } }
        public override MetaDataMember Discriminator { get { return _orgtype.Discriminator; } }
        public override bool HasAnyLoadMethod { get { return _orgtype.HasAnyLoadMethod; } }
        public override bool HasAnyValidateMethod { get { return _orgtype.HasAnyValidateMethod; } }
        public override bool HasInheritance { get { return _orgtype.HasInheritance; } }
        public override bool HasInheritanceCode { get { return _orgtype.HasInheritanceCode; } }
        public override bool HasUpdateCheck { get { return _orgtype.HasUpdateCheck; } }
        public override System.Collections.ObjectModel.ReadOnlyCollection<MetaDataMember> IdentityMembers { get { return _orgtype.IdentityMembers; } }
        public override MetaType InheritanceBase { get { return _orgtype.InheritanceBase; } }
        public override object InheritanceCode { get { return _orgtype.InheritanceCode; } }
        public override MetaType InheritanceDefault { get { return _orgtype.InheritanceDefault; } }
        public override MetaType InheritanceRoot { get { return _orgtype.InheritanceRoot; } }
        public override System.Collections.ObjectModel.ReadOnlyCollection<MetaType> InheritanceTypes { get { return _orgtype.InheritanceTypes; } }
        public override bool IsEntity { get { return _orgtype.IsEntity; } }
        public override bool IsInheritanceDefault { get { return _orgtype.IsInheritanceDefault; } }
        public override string Name { get { return _orgtype.Name; } }
        public override System.Reflection.MethodInfo OnLoadedMethod { get { return _orgtype.OnLoadedMethod; } }
        public override System.Reflection.MethodInfo OnValidateMethod { get { return _orgtype.OnValidateMethod; } }
        public override System.Collections.ObjectModel.ReadOnlyCollection<MetaDataMember> PersistentDataMembers { get { return _orgtype.PersistentDataMembers; } }
        public override Type Type { get { return _orgtype.Type; } }
        public override MetaDataMember VersionMember { get { return _orgtype.VersionMember; } }
        public override MetaDataMember GetDataMember(System.Reflection.MemberInfo member) { return _orgtype.GetDataMember(member); }
        public override MetaType GetInheritanceType(Type type) { return _orgtype.GetInheritanceType(type); }
        public override MetaType GetTypeForInheritanceCode(object code) { return _orgtype.GetTypeForInheritanceCode(code); }
        #endregion
    }
