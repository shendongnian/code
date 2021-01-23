        List<int> integerList = new List<int>();
        for (int a = 0; a < textBox1.Text.Length; a++)
        {
            for (int b = 8; b > 1 ; b--)
            {
                integerList.Add(int.Parse(textBox1.Text[a].ToString()) * b); //this line
            }
        }
        listBox1.DataSource = integerList;
