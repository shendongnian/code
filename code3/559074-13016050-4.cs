    public partial class TestForm : Form, ITestView
    {
        public event EventHandler Load;
    
        public void LoadList(IEnumerable<AppSignature> data)
        {
            testPresenterBindingSource.DataSource = data;
        }
    
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            if (Load != null)
                Load(this, EventArgs.Empty);
        }
    
        public void LoadList(IEnumerable<AppSignature> data)
        {
            // populate grid view here
        }
    } 
  
