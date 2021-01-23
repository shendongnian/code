    namespace MyApplication
    {
        public partial class Form1 : Form
        {
            private Downloader downloader;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.downloader = new Downloader(this);
            }
    
            private void downloadButton_Click(object sender, EventArgs e)
            {
               downloader.Whatever();
            }
        }
    }
