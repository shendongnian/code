    Partial Class Entity1:EntityBase
    {
        public SpecificObservableCollection<Entity2> Entity2_Observable
        {
            get;
            set;
        }
        partial void OnSetEntity2()
        {
            Misc_Observable.Add(Entity2);
        }
        public class SpecificObservableCollection<T> : ObservableCollection<T>
        {
            public Action<T> SetValue { get; set; }
            protected override void InsertItem(int index, T item)
            {
                base.InsertItem(index, item);
                SetValue(item);
            }
        }
        protected override void DoStuffOnAdd()
        {
                Entity2_Observable = new SpecificObservableCollection<Entity2>();
                Entity2Observable.SetValue = a => _Entity2 = a;
        }
    }
