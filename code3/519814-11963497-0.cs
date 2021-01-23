    public interface ISecurityContext
        {
            public dynamic Data { get; }
            bool CurrenUserAuthenticated();
            IEnumerable<object> CurrenUserRoles();
        }
