    public class OtherViewModel
    {
        //Expand these if you want to make it INPC
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Foo OtherValue { get; private set; }
    }
    
    public class MainViewModel
    {
        // Somewhere in MainViewModel, create the collection
        ObservableCollection<OtherViewModel> CreateCollection(ICollection<ClassA> a, ICollection<ClassB> b)
        {
            var mix = a.Join(b, a => a.Id, b => b.Id,
                (a, b) => new OtherViewModel { Id = a.Id, Name = a.Name, OtherValue = b.OtherValue });
    
            return new ObservableCollection<OtherViewModel>(mix);
        }
    
        // Expose the collection (possibly INPC if needed)
        public ObservableCollection<OtherViewModel> MixedCollection { get; private set; }
    }
