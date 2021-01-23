    class MasterViewModel
    {
        MenuViewModel;
        InfoViewModel;
        SliderViewModel;
    
        public CommunicationProperty 
        {
           set
           {
           InforViewModel.SomeProperty = value;
           }
        }
    }
    
    class SliderViewModel
    {
        pubic SliderViewModel(MasterViewModel masterViewModel)
        {
            //hold reference of master view model in a variable  
        }
    
        public SelectedItem
        {
            set
            {
                // change the info view model via master view model
                masterViewModel.CommunicationProperty = "SomeValue";
            }
        }
    }
