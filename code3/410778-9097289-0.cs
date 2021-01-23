    public partial class Form1 : Form, IMyView
    {
        MyPresenter Presenter;
        public Form1()
        {
            InitializeComponent();
            Presenter = new MyPresenter(this);
        }
    
        public string SomeData
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                MyTextBox.Text = value;
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.ChangeData();
        }
    }
    
    public interface IMyView
    {
        string SomeData { get; set; }
    }
    
    public class MyPresenter
    {
        private IMyView View { get; set; }
        public MyPresenter(IMyView view)
        {
            View = view;
            View.SomeData = "test string";
        }
    
        public void ChangeData()
        {
            View.SomeData = "Some changed data";
        }
    }
