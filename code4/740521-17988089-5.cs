    public partial class Form1 : Form
        {
            public static Form1 Global;
            public Form1()
            {
                InitializeComponent();
                Global = this;
            }
    
            public string Hash = "Your encrytped/hash/w.e";
    
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
                     using (StreamWriter write = new     StreamWriter(File.Create(save.FileName)))                
                        write.Write(Form1.Global.Hash);
                 }
            }
        }
