    public IEnumerable<string> Priority
            {
                get { return EnumExtensions.GetEnumValues<Priority>().Select(priority => priority.ToString()); }
    public string SelectedPriority
            {
                get { return Model.Priority; }
                set { Model.Priority = value; }
            }
        
