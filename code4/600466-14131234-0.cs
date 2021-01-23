    private int myVar;
    
        public AfTables Table
        {
            get { return (AfTables)myVar; }
            set { myVar = (int) value; }
        }
        
        public enum AfTables
        {
            Users,
            PermissionGroups
        }
