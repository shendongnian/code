    public sealed class MyPOCO_F874E881B0FD3EF02199CD96C63396B451E275C5116C5DFBE892C68733857FDE : MyPOCO, IEntityWithChangeTracker, IEntityWithRelationships
    {
        [NonSerialized]
        private IEntityChangeTracker _changeTracker;
        private static Func<object, object, bool> _compareByteArrays;
        [NonSerialized, IgnoreDataMember, XmlIgnore, ScriptIgnore]
        public object _entityWrapper;
        private System.Data.Objects.DataClasses.RelationshipManager _relationshipManager;
        private static Action<object> _resetFKSetterFlag;
        private void EntityMemberChanged(string text1)
        {
            if (this._changeTracker != null)
            {
                this._changeTracker.EntityMemberChanged(text1);
            }
        }
        private void EntityMemberChanging(string text1)
        {
            if (this._changeTracker != null)
            {
                this._changeTracker.EntityMemberChanging(text1);
            }
        }
        public void SetChangeTracker(IEntityChangeTracker tracker1)
        {
            this._changeTracker = tracker1;
        }
        public override int ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                if (base.ID != value)
                {
                    try
                    {
                        this.EntityMemberChanging("ID");
                        base.ID = value;
                        this.EntityMemberChanged("ID");
                    }
                    finally
                    {
                        _resetFKSetterFlag(this);
                    }
                }
            }
        }
        public System.Data.Objects.DataClasses.RelationshipManager RelationshipManager
        {
            get
            {
                if (this._relationshipManager == null)
                {
                    this._relationshipManager = System.Data.Objects.DataClasses.RelationshipManager.Create(this);
                }
                return this._relationshipManager;
            }
        }
        public override int? Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                try
                {
                    this.EntityMemberChanging("Value");
                    base.Value = value;
                    this.EntityMemberChanged("Value");
                }
                finally
                {
                    _resetFKSetterFlag(this);
                }
            }
        }
    }
    
