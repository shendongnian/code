    public  interface   IEntity
                        <
                            TIEntity, 
                            TDataObject, 
                            TDataObjectList, 
                            TIBusiness, 
                            TIDataAccess, 
                            TPrimaryKeyDataType
                        >
            where       TIEntity            : IEntity<TIEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKeyDataType>
            where       TDataObject         : IEntity<TIEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKeyDataType>.BaseDataObject
            where       TDataObjectList     : IEntity<TIEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKeyDataType>.IDataObjectList
            where       TIBusiness          : IEntity<TIEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKeyDataType>.IBaseBusiness
            where       TIDataAccess        : IEntity<TIEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKeyDataType>.IBaseDataAccess
            where       TPrimaryKeyDataType : IComparable<TPrimaryKeyDataType>, IEquatable<TPrimaryKeyDataType>
    {
        public  class       BaseDataObject
        {
            public  TPrimaryKeyDataType Id  { get; set; }
        }
        public  interface   IDataObjectList : IList<TDataObject>
        {
            TDataObjectList ShallowClone();
        }
        public  interface   IBaseBusiness
        {
            void            Delete(TPrimaryKeyDataType id);
            TDataObjectList Load(TPrimaryKeyDataType id);
            TDataObjectList Save(TDataObjectList items);
            bool            Validate(TDataObject item);
        }
        public  interface   IBaseDataAccess
        {
            void            Delete(TPrimaryKeyDataType id);
            TDataObjectList Load(TPrimaryKeyDataType id);
            TDataObjectList Save(TDataObjectList items);
        }
    }
