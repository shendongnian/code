    class MyClass
    {
        ...
        public MyGroup GroupName { get; set; } // used to group MyClass objects
    }
    class MyGroup
    {
        public string HeaderText { get; set; }
        // maybe you will need an additional property to make this object
        // unique for grouping (e.g. for different groups with same HeaderText)
    }
.
    <Expander.Header>
        <TextBlock Text="{Binding Path=Name.HeaderText}" />
    </Expander.Header>
