    public void SomeOperation()
    {
        using (var context = this.contextFactory.CreateNew())
        {
            var entities =
                this.otherDependency.Operate(context, "some value");
            context.Entities.InsertOnSubmit(entities);
            context.SaveChanges();
        }
    }
