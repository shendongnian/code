    using System ;
    using System.Windows.Forms;
    
    namespace OperationErrorDelegate
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                DAL DAL = new DAL();
                DAL.ReportError += new OperationErrorHandler(DAL_OperationErrorProgress);
                DAL.DoDALOperationThatCausesError();
            }
        private void DAL_OperationErrorProgress(Exception ex)
        {
            label1.Text = ex.Message;
        }
    }
}
