    public class ObjectBase
    {
        private bool _isDirty;
        private bool _isNew = true;
        protected void MarkDirty()
        {
             _isDirty = true;
        }
        protected void MarkAsNew()
        {
             _isNew = true;
        }
        public bool IsDirty
        {
             get { return _isDirty; }
        }
      }
