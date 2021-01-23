    partial class MyContext: ObjectContext
    {
        partial void OnContextCreated()
        {
            this.CommandTimeout = 300;
        }
    }
