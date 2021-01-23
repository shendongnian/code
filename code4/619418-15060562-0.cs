    public interface IClassFoo
    {
       string Name { get; }
    }
    public class ClassFoo : IClassFoo
    {
        public string Name { get { return "Antonio"; } }
    }
    //Usage 
    var someCollection = new ObservableCollection<IClassFoo>();
