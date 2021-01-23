    namespace:MyModel
    {
    #region Contexts 
    public partial class MyEntities : ObjectContext
    {
        #region Constructors
    public MyEntities(EntityConnection connection) //add the required arguments
            : base(connection, "Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    ....
