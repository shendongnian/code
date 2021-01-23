    private bool _data;
    public ButtonData Data {
        get { return _data; }
        set {
            if (value != _data) {
                // Unhook previous events
                if (_data != null)
                    _data.PropertyChanged -= HandleButtonDataPropertyChanged;
                // Set private field
                _data = value;
                // Hook new events
                if (_data != null)
                    _data.PropertyChanged += HandleButtonDataPropertyChanged;
                // Immediate update  since we have a new ButtonData object
                if (_data != null)
                    Update();
            }
        }
    }
              
    private void HandleButtonDataPropertyChanged(object sender, PropertyChangedEventArgs e) {
        // Handle change in ButtonData
        Update();
    }
    
    private void Update() {
        // Update...
    }
