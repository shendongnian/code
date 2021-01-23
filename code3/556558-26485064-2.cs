        static void Main()
        {
            var ui = new Ui();
            var model = new Model();
            // setup two-way binding
            model.PropertyChanged += (propertyName, value) =>
            {
                if (propertyName == "Title")
                    ui.Title = (string) value;
            };
            ui.PropertyChanged += (propertyName, value) =>
            {
                if (propertyName == "Title")
                    model.Title = (string) value;
            };
            // test
            model.Title = "model";
            Console.WriteLine("ui.Title = " + ui.Title); // "ui.Title = model"
            ui.Title = "ui";
            Console.WriteLine("model.Title = " + model.Title);// "model.Title = ui"
            Console.ReadKey();
        }
    }
    public class Ui : Bindable
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value) return;
                _title = value; 
                OnChange("Title", value); // fire PropertyChanged event
            }
        }
    }
    public class Model : Bindable
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value) return;
                _title = value; 
                OnChange("Title", value); // fire PropertyChanged event
            }
        }
    }
    public class Bindable
    {
        public delegate void PropertyChangedEventHandler(
            string propertyName, object value);
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnChange(string propertyName, object value)
        {
            if (PropertyChanged != null)
                PropertyChanged(propertyName, value);
        }
    }
