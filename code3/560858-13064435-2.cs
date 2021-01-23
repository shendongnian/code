    public ObservableCollection<FPGAViewModel> Children { get; set; }
        public ParentViewModel()
        {
            Children = new ObservableCollection<FPGAViewModel>();
            Children.Add(new FPGAViewModel() { RadioBase = "Base 0x0" });
            Children.Add(new FPGAViewModel() { RadioBase = "Base 0x40" });
            Children.Add(new FPGAViewModel() { RadioBase = "Base 0x80" });
            Children.Add(new FPGAViewModel() { RadioBase = "Base 0xc0" });
        }
