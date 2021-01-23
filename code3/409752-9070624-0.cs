    public class SomeClassB
    {
        public ObservableCollection<SomeClassA> Name_Col { get; set; }
        public void MethodA()
        {
            Name_Col = new ObservableCollection<SomeClassA>();
            Name_col.Add(new SomeClassA { FirstName = "SomeValue" });
        }
    }
