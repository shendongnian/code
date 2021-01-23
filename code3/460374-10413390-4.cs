     public class SomeViewModel
        {
            public SomeViewModel()
            {
                DoItCommand = new DelegateCommand(() => Debug.WriteLine("It Worked"));
            }
    
            public ICommand DoItCommand { get; private set; }
        }
