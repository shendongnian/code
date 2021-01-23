        public int GetHashCode(ISyncableUser obj)
        {
            if (obj == null)
            {
                return SOME_CONSTANT;
            }
            if (<strong>HaveUpnWithSomeUser</strong>(obj))
            {
                return <strong>GetHashCode</strong>(obj.UserPrincipalName);
            }
            return GetHashCode(obj.Guid);
        }
