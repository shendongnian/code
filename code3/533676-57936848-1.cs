    public static List<string> HTMLFiles = new List<string>();
 private void Form1_Load(object sender, EventArgs e)
        {
     HTMLFiles.AddRange(Directory.GetFiles(@"C:\DataBase", "*.txt"));
            foreach (var item in HTMLFiles)
            {
                MessageBox.Show(item);
            }
}
