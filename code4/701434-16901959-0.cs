    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                button1.Enabled = false;
                backgroundWorker.RunWorkerAsync();
            }
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SomeClass AnotherClass = new SomeClass();
            AnotherClass.Blah(this);
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            MessageBox.Show("Done!");
        }
    }
    public class SomeClass
    {
        public void Blah(Form frm)
        {
            int item_quantity = 5;
            for (int i = 0; i < item_quantity; i++)
            {
                try
                {
                    //File.Delete(item[0, i]);
                    Console.WriteLine("i = " + i.ToString());
                    throw new Exception("duh");
                }
                catch (Exception ex)
                {
                    frm.Invoke(new Action(() =>
                        {
                            DialogResult result = MessageBox.Show(frm, String.Format("Error while accessing {0}\n{1}", "something", ex.Message), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            if (result == DialogResult.Retry)
                            {
                                i--;
                            }
                        }));
                }
            }
        }
    }
