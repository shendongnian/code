    using Microsoft.Practices.Prism.ViewModel;
    namespace YourNamespace
    {
        public class MyUserControlViewModel : NotificationObject
        {
            private double _sliderValue;
            public double SliderValue
            {
                get { return _sliderValue; }
                set
                {
                    _sliderValue = value;
                    RaisePropertyChanged(() => SliderValue);
                }
            }
        }
    }
