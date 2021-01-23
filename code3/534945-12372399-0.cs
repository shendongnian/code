     public class PersonViewModel : ViewModelBase
        {
            private PersonModel _PersonModel;
            private ICommand _EditPersonCommand;
    
            ///<remarks>
            /// must use the parameterless constructor to satisfy <Window.Resources>
            ///</remarks>
            public PersonViewModel()
                : this(new PersonModel())
            {
    
            }
    
            public PersonViewModel(PersonModel personModel)
            {
                PersonModelProp = personModel;
            }
    
            public ICommand EditPersonCommand
            {
                get
                {
                    if (_EditPersonCommand == null)
                    {
                        _EditPersonCommand = new RelayCommand(ExecuteEditPerson,CanExecuteEditPerson);
                    }
                    return _EditPersonCommand;
                }
            }
    
    
            private bool CanExecuteEditPerson(object parameter)
            {
                PersonModel p = parameter as PersonModel;
                
                return (p != null) && (p.Age > 0);
            }
    
    
            private void ExecuteEditPerson(object o)
            {
    
            }
    
    
            public PersonModel PersonModelProp
            {
                get
                {
                    return _PersonModel;
                }
                set
                {
                    _PersonModel = value;
                    NotifyPropertyChanged("PersonModelProp");
                }
            }
            
    
        }
    
    
    
