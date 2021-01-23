    namespace MyApplication
    {
        public partial class Form1 : Form
        {
            Downloader downloader;
            // either of the following two will work
            private void Form1_Load(object sender, EventArgs e)
            {
                downloader = new Downloader(this);
            }
            private void downloadButton_Click(object sender, EventArgs e)
            {
                downloader = new Downloader(this);
            }
        }
    }
