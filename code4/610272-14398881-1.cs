        public partial class Form1 : Form
        {
          private void btn_do_Click(object sender, EventArgs e)
          { 
            CountToTen obj= new CountToTen();
             obj.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
             obj.bw.RunWorkerAsync();
           }
           void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){}       
        }
        class CountToTen 
        {
        public BackgroundWorker bw = new BackgroundWorker();
        public CountToTen()
        {
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Do your Stuff
        }
        }
 
