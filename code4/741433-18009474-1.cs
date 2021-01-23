     public partial class RemoveAds : Form
    {
        OpenFileDialog ofd = null;
        string path = @"C:\Users\Monika\Documents\Visual Studio 2010\Projects\OnlineExam\OnlineExam\Image\"; // this is the path that you are checking.
        string fullFilePath;
        public RemoveAds()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(path))
            {
                 ofd = new OpenFileDialog();
                ofd.InitialDirectory = path;
                DialogResult dr = new DialogResult();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Image img = new Bitmap(ofd.FileName);
                    string imgName = ofd.SafeFileName;
                    txtImageName.Text = imgName;
                    pictureBox1.Image = img.GetThumbnailImage(350, 350, null, new IntPtr());
                    fullFilePath = ofd.FilePath;
                    ofd.RestoreDirectory = true;
                }
            }
            else
            {
                return;
            } 
        }
        private void button2_Click(object sender, EventArgs e)
            {
                 FileInfo file = new FileInfo(fullFilePath);
                 if(!IsFileLocked(file))
                     file.Delete(); 
             }
        }
        public static Boolean IsFileLocked(FileInfo path)
        {
            FileStream stream = null;   
            try
            { //Don't change FileAccess to ReadWrite,
                //because if a file is in readOnly, it fails.
                stream = path.Open ( FileMode.Open, FileAccess.Read, FileShare.None ); 
            } 
            catch (IOException) 
            { //the file is unavailable because it is:
                //still being written to or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            } 
            finally
            { 
                if (stream != null)
                    stream.Close();
            }   
            //file is not locked
            return false;
        }
    }
