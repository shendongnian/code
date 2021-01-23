    interface IParent
    {
        void ParentMethod();
    }
    interface IChild
    {
        new void ParentMethod(); // Reimplement IParent.ParentMethod()
        void ChildMethod();
    }
