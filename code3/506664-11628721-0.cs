    interface IEntityWithName
    {
        string Name { get; set; }
    }
    // make sure this is in the same namespace and has the same name as the generated class
    partial class YourEntity1 : IEntityWithName
    {
    }
    // ditto
    partial class YourEntity2 : IEntityWithName
    {
    }
    public void DoSomething<T>(T entity)
        // if you have no common base class
        where entity : class, IEntityWithName
        // or if you do have a common base class
        where entity : EntityObject, IEntityWithName
    {
        MessageBox.Show(entity.Name);
    }
