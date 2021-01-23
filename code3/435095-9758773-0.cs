    public class Car : INotifyPropertyChanged
     {
       private string _make;
       private string _model;
       private int _year;
     
      public event PropertyChangedEventHandler PropertyChanged;
     
      public Car(string make, string model, int year)
       {
         _make = make;
         _model = model;
         _year = year;
       }
     
      public string Make
       {
         get { return _make; }
         set
         {
           _make = value;
           this.NotifyPropertyChanged("Make");
         }
       }
     
      public string Model
       {
         get { return _model; }
         set
         {
           _model = value;
           this.NotifyPropertyChanged("Model");
         }
       }
     
      public int Year
       {
         get { return _year; }
         set
         {
           _year = value;
           this.NotifyPropertyChanged("Year");
         }
       }
     
      private void NotifyPropertyChanged(string name)
       {
         if(PropertyChanged != null)
           PropertyChanged(this, new PropertyChangedEventArgs(name));
       }
     }
    
    _dgCars.AutoGenerateColumns = false;
     
    DataGridViewTextBoxColumn makeColumn = new DataGridViewTextBoxColumn();
     makeColumn.DataPropertyName = "Make";
     makeColumn.HeaderText = "The Car's Make";
     
    DataGridViewTextBoxColumn modelColumn = new DataGridViewTextBoxColumn();
     modelColumn.DataPropertyName = "Model";
     modelColumn.HeaderText = "The Car's Model";
     
    DataGridViewTextBoxColumn yearColumn = new DataGridViewTextBoxColumn();
     yearColumn.DataPropertyName = "Year";
     yearColumn.HeaderText = "The Car's Year";
     
    _dgCars.Columns.Add(makeColumn);
     _dgCars.Columns.Add(modelColumn);
     _dgCars.Columns.Add(yearColumn);
     
    BindingList<Car> cars = new BindingList<Car>();
     
    cars.Add(new Car("Ford", "Mustang", 1967));
     cars.Add(new Car("Shelby AC", "Cobra", 1965));
     cars.Add(new Car("Chevrolet", "Corvette Sting Ray", 1965));
     
    _dgCars.DataSource = cars;
