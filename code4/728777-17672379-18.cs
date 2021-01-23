    public partial class TempCalib : Form
    {
        public event EventHandler SomethingMustBeDone;
        
        private void OkButton_Click(object sender, EventArgs e)
        {
            OnSomethingMustBeDone(EventArgs.Empty); / TO DO
           this.Hide();
        }
    }
