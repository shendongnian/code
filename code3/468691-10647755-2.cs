    namespace Project.Namespace.ViewModels.DataSamples
    {
        public class NationViewModelSampleData : Project.Namespace.ViewModels.INationViewModel
        {
            public NationViewModelSampleData()
            {
                // You could have done something like this as well, but for this sample was more code to write.
                // Leader = Substitute.For<IPerson>();
                // Leader.FirstName.Returns("John");
                // Leader.LastName.Returns("Doe");
                // or just...
                Leader = new Person { FirstName = "John", LastName = "Doe" };
     
                Citizens = new IPerson[]
                           {
                               new Person { FirstName = "Malcolm", LastName = "Little" },
                               Leader
                           };
                // You could have applied the mock to this section as well... again, more code for this scenario than just a simple real instance.
            }
    
            public IPerson Leader { get; private set; }
            public IEnumerable<IPerson> Citizens { get; private set; } 
        }
    }
