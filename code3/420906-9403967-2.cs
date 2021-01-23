    public <#=code.Escape(container)#>(string connectionString)
        : base(connectionString, ContainerName)
    {
    <#
        WriteLazyLoadingEnabled(container);
    #>
        // Call the OnContextCreated() method to perform any necessary 'post creation' setup
        OnContextCreated();
    }
    // Define the OnContextCreated partial method so that the accompanying partial Context 
    // class can implement this method.
    partial void OnContextCreated();
