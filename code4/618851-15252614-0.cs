    public class PopupParentWindowFocusBehavior : Behavior<Popup>
    {
        private bool _hidden;
        private UIElement _lastPlacementTarget;
        private System.Windows.Window _lastWindow;
        private PropertyChangeNotifier _placementTargetNotifier;
        protected override void OnAttached()
        {
            base.OnAttached();
            InitializeForPlacementTarget();
            _placementTargetNotifier = new PropertyChangeNotifier(AssociatedObject, Popup.PlacementTargetProperty).AddValueChanged(OnPlacementTargetChanged);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            DetachWindowEvents();
            if (_lastPlacementTarget != null)
            {
                ((Control)_lastPlacementTarget).Loaded -= OnPlacementTargetLoaded;
            }
            _placementTargetNotifier.ValueChanged -= OnPlacementTargetChanged;
        }
        private void OnPlacementTargetChanged(object sender, EventArgs e)
        {
            InitializeForPlacementTarget();
        }
        private void InitializeForPlacementTarget()
        {
            if (_lastPlacementTarget != null)
            {
                ((Control)_lastPlacementTarget).Loaded -= OnPlacementTargetLoaded;
            }
            if (AssociatedObject.PlacementTarget != null)
            {
                ((Control)AssociatedObject.PlacementTarget).Loaded += OnPlacementTargetLoaded;
                AttachWindowEvents();
            }
            _lastPlacementTarget = AssociatedObject.PlacementTarget;
        }
        private void OnPlacementTargetLoaded(object sender, RoutedEventArgs e)
        {
            AttachWindowEvents();
        }
        private void OnWindowClosed(object sender, EventArgs e)
        {
            DetachWindowEvents();
        }
        private void AttachWindowEvents()
        {
            if (_lastWindow != null)
            {
                DetachWindowEvents();
            }
            System.Windows.Window window = System.Windows.Window.GetWindow(AssociatedObject.PlacementTarget);
            if (window != null)
            {
                window.Deactivated += OnWindowDeativated;
                window.Activated += OnWindowActivated;
                window.Closed += OnWindowClosed;
            }
            _lastWindow = window;
        }
        private void DetachWindowEvents()
        {
            if (_lastWindow != null)
            {
                _lastWindow.Deactivated -= OnWindowDeativated;
                _lastWindow.Activated -= OnWindowActivated;
                _lastWindow.Closed -= OnWindowClosed;
            }
        }
        private void OnWindowDeativated(object sender, EventArgs e)
        {
            System.Windows.Window window = System.Windows.Window.GetWindow(AssociatedObject.PlacementTarget);
            if (window != null && AssociatedObject.IsOpen)
            {
                _hidden = true;
                AssociatedObject.IsOpen = false;
            }
        }
        private void OnWindowActivated(object sender, EventArgs e)
        {
            if (_hidden)
            {
                _hidden = false;
                AssociatedObject.IsOpen = true;
            }
        }
    }
