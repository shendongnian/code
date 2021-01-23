     public static class DataHolder
        {
            private static string _hash;
            public static string Hash { get { return _hash; } set { _hash = value; } }
        }
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                
            }
    
            public void SetHash()
            {
                DataHolder.Hash = "You Hash";           
            }
    
            Form2 form2 = new Form2();
            
        }
    
        public partial class Form2 : Form
        {
            public Form2()
            {
                 SaveFileDialog save = new SaveFileDialog();
                 save.DefaultExt = ".txt";
                 if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 {
                     using (StreamWriter write = new StreamWriter(File.Create(save.FileName)))                
                        write.Write(DataHolder.Hash);
                 }
            }
        }
