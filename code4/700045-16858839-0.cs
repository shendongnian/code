    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Globalization;
    using System.IO;
    namespace SpeedDating
    {
        class Program
        {
             [STAThread]
            static void Main(string[] args)
            {
                string filename = "test.test"; // args[0];
                string ext = filename.Substring(filename.LastIndexOf('.'));
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Title = "SpeedDating App by K.Toet";
                    dialog.RestoreDirectory = true;
                    dialog.CheckFileExists = false;
                    dialog.CheckPathExists = false;
                    dialog.FileName = DateTime.Now.ToString("yyyyMMdd") + ext;
    
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK && dialog.FileName != "")
                    {
                        try
                        {
                            FileStream outfs = File.Create(dialog.FileName);
                            FileStream infs = File.Open(filename, FileMode.Open);
                            infs.CopyTo(outfs);
                            infs.Close();
                            outfs.Close();
                        }
                        catch (NotSupportedException ex)
                        {
                            MessageBox.Show("Probably removed the original file.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No path found to write to.");
                    }
                }
    
                MessageBox.Show("I came here and all I got was this louzy printline");
            }
        }
    }
