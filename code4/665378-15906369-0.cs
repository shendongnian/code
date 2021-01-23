    class MyDatViewModel : INotifyPropertyChanged
    {
        public string Str
        {
            // ... Get Set
        }
        public int NestedObjNum
        {
            // ... Get set
        }
    }
    // Configure AutoMapper
  
    Mapper.CreateMap<MyDat, MyDatViewModel>();
  
    // Perform mapping
  
    MyDatViewModel viewModel = Mapper.Map<MyDat, MyDatViewModel>(someData);
