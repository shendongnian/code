    public partial Form2 : Form 
    {
    public string path = Environment.CurrentDirectory + "/" + "Name.txt";
       public Form2()
       {
           InitializeComponent();
           if (!File.Exists(path))
           {
                File.Create(path);
           }
     
       }
         private void button2_Click(object sender, EventArgs e)
         {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
              sw.WriteLine("This text will be writen in the txt file", true);
              sw.Close();
            }
         }
    }
