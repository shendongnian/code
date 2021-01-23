     public sealed class Counter2 : IEnumerable<MyClass>
        {
            private ObservableCollection<MyClass> m_Collection = new ObservableCollection<MyClass>();
    
            public ObservableCollection<MyClass> Collection
            {
                get
                {
                    return m_Collection;
                }
            }
           
        }
