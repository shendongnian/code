    for (int x = 0; x < symboltable1.GetLength(0); x++)
    {
        for (int y = 0; y < symboltable1.GetLength(1); y++)
        {
            for (int z = 0; z < text.Length; z++)
            {
                if (symboltable1[x,y] == text[z])
                    listBox2.Items.Add(text[z]);
                else
                    MessageBox.Show("poor");
            }
        }
    }
