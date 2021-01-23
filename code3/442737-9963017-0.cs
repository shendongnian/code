    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            // register your types with your favourite DI container
        }
        public MainViewModel Main
        {
            get 
            { 
                var vm = // resolve singleton instance, data obtained in constructor
                return vm;
            }
        }
