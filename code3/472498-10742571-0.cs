    public class View
    {
        private Model _model = new Model();
        public View()
        {
        }
        public Controller
        {
            get;
            set;
        }
        private void OnButton1Click(object sender, EventArgs args)
        {
            _model.Option = Options.Option1;
        }
        private void OnSaveClick(object sender, EventArgs args)
        {
            if (Controller != null)
                Controller.ApplyChanges(_model);
        }
    }
