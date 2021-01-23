    public interface IWorkspace
    {
        Uri Uri { get; set; }
        string Title { get; set; }
    }
    
    public class Workspace : IWorkspace
    {
        #region Implementation of IWorkspace
    
        public Uri Uri { get; set; }
        public string Title { get; set; }
    
        #endregion
    
        public Workspace(string workspace)
        {
            if (string.IsNullOrEmpty(workspace))
                return;
    
            var workspaceArray = workspace.Split(new[] { ',' });
    
            if (workspaceArray.Length > 0)
                Uri = new Uri(workspaceArray[0]);
    
            if (workspaceArray.Length > 1)
                Title = workspaceArray[1];
    
        }
    }
    
    public class WorkspaceType : IUserType
    {
        #region Implementation of IUserType
    
        public bool Equals(object x, object y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.GetType() == y.GetType();
        }
    
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
    
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var property0 = NHibernateUtil.String.NullSafeGet(rs, names[0]);
    
            if (property0 == null)
            {
                return null;
            }
    
            Workspace workspace = new Workspace(property0.ToString());
    
            return workspace;
        }
    
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                var state = (IWorkspace)value;
                ((IDataParameter)cmd.Parameters[index]).Value = state.GetType().Name;
            }
        }
    
        public object DeepCopy(object value)
        {
            return value;
        }
    
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    
        public object Assemble(object cached, object owner)
        {
            return cached;
        }
    
        public object Disassemble(object value)
        {
            return value;
        }
    
        public SqlType[] SqlTypes { get { return new[] { NHibernateUtil.String.SqlType }; } }
        public Type ReturnedType { get { return typeof(Workspace); } }
        public bool IsMutable { get { return false; } }
    
        #endregion
    }
