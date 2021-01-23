    // The ViewModel is responsible for handling the actual visual layout of the form.
    public class ViewModel {
        // Fire this when your ViewModel changes
        public event EventHandler WindowUpdated;
        public Boolean IsIsNullCheckBoxVisible { get; private set; }
        // This method would contain the actual logic for handling window changes.
        public void CalculateFormLayout() {
            Boolean someLogic = true;
            // If the logic is true, set the isNullCheckbox to true
            if (someLogic) {
                IsIsNullCheckBoxVisible = true;
            }
            // Inform the UI to update
            UpdateVisual();
        }
        // This fires the 'WindowUpdated' event.
        public void UpdateVisual() {
            if (WindowUpdated != null) {
                WindowUpdated(this, new EventArgs());
            }
        }
    }
    public class TheUI : Form {
        // Attach to the viewModel;
        ViewModel myViewModel = new ViewModel();
        CheckBox isNullCheckBox = new CheckBox();
        public TheUI() {
            this.myViewModel.WindowUpdated += myViewModel_WindowUpdated;
        }
        void myViewModel_WindowUpdated(object sender, EventArgs e) {
            // Update the view here.
            // Notie that all we do in the UI is to update the visual based on the
            // results from the ViewModel;
            this.isNullCheckBox.Visible = myViewModel.IsIsNullCheckBoxVisible;
        }
    }
