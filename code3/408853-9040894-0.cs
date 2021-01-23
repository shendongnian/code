    public class DepartmentCollection : KeyedCollection<String, Department> {
        public String GetKeyForItem(Department item)
        {
            // EDIT: For your use case, this should work
            return item.UniqueName;
        }
    }
