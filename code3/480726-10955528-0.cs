    public IManageableEntryDao<T> CreateDao<T>() where T : IManageableEntry
    {
            Type manageableEntryType = typeof(T);
            // You'll need to modify daoTypes to be a HashSet<Type> (or List<Type>) of allowable types, or something similar, instead of using a dictionary lookup
            if (daoTypes.Contains(manageableEntryType) {
                object dao = Activator.CreateInstance(type);                    
                return dao as IManageableEntryDao<T>;
            }
            throw new NotImplementedException("Failed to find DAO for type: " + manageableEntryType);
        }
