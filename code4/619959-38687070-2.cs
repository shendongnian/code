    //VIEWMODEL
    public class Person : INotifyPropertyChanged
    {
        string _firstName;
        string _lastName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if(value != _firstName)
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
    //MODEL
    class Model
    {
        Person _person;
        public Person Person { get { return _person; } }
        public Model()
        { 
            //Set default value
            _person = new Person(){ FirstName = "Test", LastName = "Subject" };
        }
        public void ChangePerson()
        {
            //When presenter calls this method, it will change the underlying source field and will reflect the changes in the View.
            _person.FirstName = "Homer";
            _person.LastName = "Simpson";
        }
    }
    
    //PRESENTER
    class Presenter
    {
        readonly View _view;
        readonly Model _model;
        public Presenter(View view)
        {
            _view = view;
            _model = new Model();
            _view.OnViewLoad += Load;
            _view.OnChangePerson += ChangePerson;
        }
        private void Load()
        {
            _view.Person = _model.Person;
        }
        private void ChangePerson()
        {
            _model.ChangePerson();
        }
    }
    //IVIEW
    interface IView
    {
       Person person { set; }
       event Action OnViewLoad;
       event Action OnChangePerson;
    }
    //VIEW
    public partial class View : IView
    {
         public View()
         {
             Presenter presenter = new Presenter(this); 
             this.Load += (s, e) => OnViewLoad(); //Shorthand event delegate
             this.btnChange.Click += (s, e) => OnChangePerson(); //Shorthand event delegate
         }
         public event Action OnViewLoad;
         public event Action OnChangePerson;
     
         public Person person
         {   //This is how you set textbox two-way databinding
             set
             {
                   //Databinding syntax: property of control, source, source property, enable formatting, when to update datasource, null value
                   txtFirstName.DataBindings.Add(new Binding("Text", value, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
                   txtLastName.DataBindings.Add(new Binding("Text", value, "LastName", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty)); 
             }
         }
    
    }
