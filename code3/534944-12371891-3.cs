    public class PersonViewModel : ViewModelBase
    {
      private PersonModel _PersonModel;
      private EditPersonCommand _EditPersonCommand;
      ///<remarks>
      /// must use the parameterless constructor to satisfy <Window.Resources>
      ///</remarks>
      public PersonViewModel()
         : this(new PersonModel())
      {
          _EditPersonCommand = new EditPersonCommand();
      }
      public PersonViewModel(PersonModel personModel)
      {
         _PersonModel = personModel;
      }
      public ICommand EditPersonCommand
      {
         get
         {
             return _EditPersonCommand;
         }
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
             OnPropertyChanged("PersonModelProp");
             EditPersonCommand.RaiseCanExecuteChanged();
          }
        }
    }
