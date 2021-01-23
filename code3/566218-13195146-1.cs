        public int GetHashCode(ISyncableUser obj)
        {
            if (obj == null)
            {
                return SOME_CONSTANT;
            }
            if (!string.IsNullOrWhiteSpace(obj.UserPrincipalName) &&
                &lt;can have user object with different guid and the same name&gt;)
            {
                return GetHashCode(obj.UserPrincipalName);
            }
            return GetHashCode(obj.Guid);
        }
