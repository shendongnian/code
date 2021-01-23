    public class ViewModel 
    {
        public IView View { get; set; }
        public void AddTextBoxToGrid() 
        {
            if (View == null) return;
            View.AddTextBoxToGrid()
        }
    }
