    private void quicksort1_Click(object sender, EventArgs e)
    {
      using (var output = new System.IO.StreamWriter("OUTPUT.txt"))
      {
        string[] parts = File.ReadAllLines(textBox1.Text);
        Array.Sort(parts);
        foreach (string s in parts)
        {
            output.WriteLine(s);
        }
        output.WriteLine("There were {0} lines read in.", parts.Length);
      }
