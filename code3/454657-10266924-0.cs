    internal interface IClassName { string Name { get; set; } }
    public class MyList : Collection<IClass>
    {
        protected override void InsertItem(int index, IClass item)
        {
            var className = item as IClassName;
            if (className != null)
            {
                // do something with className.Name ...
            }
            base.InsertItem(index, item);
        }
    }
    public class B : IClassName { string IClassName.Name { get; set; } }
