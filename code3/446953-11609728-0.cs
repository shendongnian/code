    public class ProjectView : IProjectView
    {
        ProjectPresenter _presenter;
        public ProjectView()
        {
            _presenter = new ProjectPresenter(this);
        }
        string textBoxText
        {
            get
            {
                // Do validation if you want
                return textBox1.Text;
            }
        }
    }
    class ProjectPresenter
    {
        IProjectView _view;
        public ProjectPresenter(IProjectView view)
        {
            _view = view;
        }
    
        public void AnyMethod()
        {
            // Access value of textbox as _view.txtTextBoxText
        }
    }
