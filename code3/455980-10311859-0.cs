    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.IO;
    namespace UploadTester
    {
        public partial class frmMain : Form
        {
            public frmMain()
            {
                InitializeComponent();
            }
    
            private void btnSelectFile_Click(object sender, EventArgs e)
            {
                openFileDialog1.ShowDialog();
                textBox1.Text = openFileDialog1.FileName;
            }
    
            private void btnUpload_Click(object sender, EventArgs e)
            {
                try
                {
                    byte[] content = GetByteArray();
                    string filename = Path.GetFileName(openFileDialog1.FileName);
    
                    System.Net.WebClient webClient = new System.Net.WebClient();
                    System.Uri uri = new Uri("http://SP/DNATestLibrary/" + filename);
                    webClient.Credentials = new NetworkCredential("username", "pwd", "domain");
    
                    webClient.UploadData(uri, "PUT", content);
    
                    MessageBox.Show("Upload Successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
    
            byte[] GetByteArray()
            {
                FileStream fileStream = new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.Open);
                byte[] content = new byte[(int)fileStream.Length];
                fileStream.Read(content, 0, (int)fileStream.Length);
                fileStream.Close();
    
                return content;
            }
    
            private void btnUploadAsync_Click(object sender, EventArgs e)
            {
                try
                {
                    byte[] content = GetByteArray();
                    string filename = Path.GetFileName(openFileDialog1.FileName);
    
                    System.Net.WebClient webClient = new System.Net.WebClient();
                    System.Uri uri = new Uri("http://SP/DNATestLibrary/" + filename);
    
                    webClient.UploadDataCompleted += new UploadDataCompletedEventHandler(webClient_UploadDataCompleted);
                    webClient.Credentials = new NetworkCredential("username", "pwd", "domain");
    
                    webClient.UploadDataAsync(uri, "PUT", content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
    
            void webClient_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
            {
                if (e.Error == null)
                {
                    MessageBox.Show("Upload Successful");
                }
                else
                {
                    MessageBox.Show(e.ToString());
                }
    
            }
        }
    }
