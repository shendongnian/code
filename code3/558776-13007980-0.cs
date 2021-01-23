    using System;
    using System.Text;
    using System.IO;
    
    namespace ClearContents
    {
        public partial class Form1 : Form
        {
            private void btnClear_Click(object sender, EventArgs e)
            {
                //get all the files which has the .bin extension in the specified directory
                string[] files = Directory.GetFiles("D:\\", "*.bin");
    
                foreach (string f in files)
                {
                    File.WriteAllText(f, string.Empty); //clear the contents
                }
            }
        }
    }
