    public class ViewModel
    {
        public ICommand EditingSliderCommand { get; set; } // actually set the command
        public ICommand DoneEditingCommand { get; set; } // actually set the command
        public bool IsEditing { get; set; }
        ...
 
        private void AutomaticUpdate
        {
            if (IsEditing)
                return;
            Update();
        }
    }
