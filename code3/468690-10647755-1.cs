    namespace Project.Namespace.ViewModels
    {
        public interface INationViewModel
        {
            IPerson Leader { get; }
            IEnumerable<IPerson> Citizens { get; }
        }
    
        public interface IPerson
        {
            string FirstName { get; }
            string LastName { get; }
        }
    }
