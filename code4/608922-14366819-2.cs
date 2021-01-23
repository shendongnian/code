    using PB.Base;
    using PB.Interfaces;
    using PB.ValidationError;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace DynTabItems
    {
        public class MyModel : ViewModelBaseEx<MyModel>
        {
            public MyModel()
            {
                YourHeader = "You header String";
                ListOfExistingErrors = new ObservableCollection<IValidationErrorInfo<MyModel>>();
                ListOfExistingErrors.Add(new Error<MyModel>() { ErrorIndicator = "YourText", ErrorText = "Your Error Text", Predicate = s => string.IsNullOrEmpty(s.YourText) });
            }
            string _yourText;
            string _yourHeader;
            public string YourHeader
            {
                get { return _yourHeader; }
                set
                { 
                    _yourHeader = value;
                    SendPropertyChanged(() => YourHeader);
                }
            }
            public string YourText
            {
                get { return _yourText; }
                set 
                { 
                    _yourText = value;
                    SendPropertyChanged(() => YourText);
                }
            }
            public override ObservableCollection<IValidationErrorInfo<MyModel>> ListOfExistingErrors
            {
                get;
                set;
            }
        }
    }
