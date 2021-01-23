    List<int> integerList = new List<int>();
    for (int a = 0; a < textBox1.Text.Length; a++)
    {
        integerList.Add(int.Parse(textBox1.Text[a].ToString())); 
    }
    foreach (int item in integerList)
    {
        for (int b = 8; b > 1; b--)
        {
            listBox1.Items.Add(item * b);
        }
    } 
