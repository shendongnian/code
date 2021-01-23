    public class ViewFinder {
        private static ViewFinder m_Instance;
        public static ViewFinder Instance {
            get {
                if (m_Instance == null)
                    m_Instance = new ViewFinder();
                return (m_Instance);
            }
        }
        /// Maps viewmodels to windows/dialogs. The key is the type of the viewmodel, the value is the type of the window.
        private Dictionary<Type, Type> ViewDictionary = new Dictionary<Type, Type>();
        /// Private constructor because this is a singleton class.
        ///
        /// Registers the viewmodels/views.
        private ViewFinder() {
            Register(typeof(SomeViewModel), typeof(SomeWindowsForViewModel));
            Register(typeof(SomeViewModel2), typeof(SomeWindowsForViewModel2));
        }
        /// Registers a window with a viewmodel for later lookup.
        /// <param name="viewModelType">The Type of the viewmodel. Must descend from ViewModelBase.</param>
        /// <param name="windowType">The Type of the view. Must descend from WindowBase.</param>
        public void Register(Type viewModelType, Type windowType) {
            if (viewModelType == null)
                throw new ArgumentNullException("viewModelType");
            if (windowType == null)
                throw new ArgumentNullException("windowType");
            if (!viewModelType.IsSubclassOf(typeof(ViewModelBase)))
                throw new ArgumentException("viewModelType must derive from ViewModelBase.");
            if (!windowType.IsSubclassOf(typeof(WindowBase)))
                throw new ArgumentException("windowType must derive from WindowBase.");
            ViewDictionary.Add(viewModelType, windowType);
        }
        /// Finds the window registered for the viewmodel and shows it in a non-modal way.
        public void MakeWindowFor(ViewModelBase viewModel) {
            Window win = CreateWindow(viewModel);
            win.Show();
        }
        /// Finds a window for a viewmodel and shows it with ShowDialog().
        public bool? MakeDialogFor(ViewModelBase viewModel) {
            Window win = CreateWindow(viewModel);
            return (win.ShowDialog());
        }
        /// Helper function that searches through the ViewDictionary and finds a window. The window is not shown here,
        /// because it might be a regular non-modal window or a dialog.
        private Window CreateWindow(ViewModelBase viewModel) {
            Type viewType = ViewDictionary[viewModel.GetType()] as Type;
            if (viewType == null)
                throw new Exception(String.Format("ViewFinder can't find a view for type '{0}'.", viewModel.GetType().Name));
            Window win = Activator.CreateInstance(viewType) as Window;
            if (win == null)
                throw new Exception(String.Format("Activator returned null while trying to create instance of '{0}'.", viewType.Name));
            win.DataContext = viewModel;
            return win;
        }
    }
