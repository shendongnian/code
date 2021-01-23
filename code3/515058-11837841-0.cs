    public struct VersionedObject
    {
        public VersionedObject()
        {
            this.ObjectVersions = new List<object>() ;
            return ;
        }
        public VersionedObject(object o) : this()
        {
            ObjectVersions.Add(o);
            return ;
        }
        public VersionedObject( params object[] o ) : this()
        {
            ObjectVersions.AddRange( o ) ;
            return ;
        }
        public int SelectedVersion
        {
            get
            {
                int value = this.ObjectVersions.Count - 1 ;
                return value ;
            }
        }
        public List<object> ObjectVersions  ;
        public void AddObject(object m)
        {
            ObjectVersions.Add(m);
            return ;
        }
    }
