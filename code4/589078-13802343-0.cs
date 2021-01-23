       namespace Data_Sorter
        {
        public partial class Form1 : Form
        {
            
    
    public Form1()
        {
            InitializeComponent();
        }
    
        private void btnSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tbFilePath.Text = folderBrowserDialog1.SelectedPath.ToString();
        }
    
        private void btnSort_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalFiles = 0;
            string[] files = Directory.GetFiles(tbFilePath.Text, "*.txt", SearchOption.AllDirectories);
            totalFiles = files.Length;
            int i = 0;
            foreach (var file in files)
            {
                 
                backgroundWorker1.ReportProgress((i * 100) / totalFiles, file);
                i++
                string fullFilename = file.ToString();
    
                string[] pathParts = fullFilename.Split('\\');
                string date = pathParts[6];
    
                string fileName = pathParts[7];
    
                string[] partName = fileName.Split('_');
    
                string point = partName[3];
    
                Directory.CreateDirectory("Data Sorted Logs\\" + point + "\\" + date + "\\");
    
                if (Directory.Exists(("Data Sorted Logs\\" + point + "\\" + date + "\\")))
                    {
                        string destPath = (point + "\\" + date + "\\");
                        File.Copy(fullFilename, "C:\\Documents and Settings\\PC\\Desktop\\Sorter\\Data Sorter\\bin\\Debug\\Data Sorted Logs\\" + destPath + fileName);                    }
                else
                    {
                        MessageBox.Show("destination folder not found " + date + point);
                    }
    
                totalFiles++;
            }
        }
    
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done");
        }
    
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar1.Text = e.UserState;
        }
    }
