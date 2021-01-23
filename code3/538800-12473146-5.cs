    public void Form1_Load(object s, EventArgs e)
    {
      using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "maincode.txt"))) {
        sw.WriteLine("00000012{0:yyyyMMdd}{1}{0:HHmmss}", DateAndTime.Now, (new Random()).Next(0, 2) == 0 ? "0010" : "0054");
      }
    }
