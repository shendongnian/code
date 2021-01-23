    public class ViewModelLocator
    {
        ...
        public MainViewModel Main
        {
            get 
            { 
                var vm = // resolve singleton instance
                vm.RefreshData(); // data obtained/updated here
                return vm;
            }
        }
