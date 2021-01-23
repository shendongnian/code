    /// <summary>
    /// ViewModel for the Main Window
    /// </summary>
    class MainViewModel
    {
        public ApplicationModel Model { get; set; }
        public MainViewModel()
        {
            Model = new ApplicationModel();
            Model.ListOfThingsToDo.Add("Clean the yard");
            Model.ListOfThingsToDo.Add("Walk dog");
        }
        // Some method that will be called when you want to open another window
        public void OpenTheWindow()
        {
            var modalViewModel = new NewTaskViewModel(Model);
            // Create an instance of your new Window and show it. 
            var win = new NewTaskWindow(modalViewModel);
            win.ShowDialog();
        }
    }
    /// <summary>
    /// Model to hold the data
    /// </summary>
    class ApplicationModel
    {
        public ObservableCollection<string> ListOfThingsToDo { get; set; }
        public ApplicationModel()
        {
            ListOfThingsToDo = new ObservableCollection<string>();
        }
    }
    /// <summary>
    /// ViewModel to handle adding new things to do
    /// </summary>
    class NewTaskViewModel
    {
        public ApplicationModel Model { get; set; }
        public NewTaskViewModel(ApplicationModel model)
        {
            Model = model;
        }
        // Add methods here that will be called to add tasks to the Model.ListOfThingsToDo
        public void AddTask()
        {
            Model.ListOfThingsToDo.Add("the new task to do");
        }
    }
