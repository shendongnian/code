    using System;
    using System.Windows.Forms;
    using System.IO;
    
    namespace Stackoverflow
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            static string Hash = "Your encrytped/hash/w.e";
    
            Form2 form2 = new Form2(Hash);
        }
    
        public partial class Form2 : Form
        {
            public Form2(string Hash)
            {
                 SaveFileDialog save = new SaveFileDialog();
                 save.DefaultExt = ".txt";
                 if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 {
                     using (StreamWriter write = new StreamWriter(File.Create(save.FileName)))                
                        write.Write(Hash);
                 }
            }
        }
    }
