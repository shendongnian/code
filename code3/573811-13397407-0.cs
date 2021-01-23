    for (int tx = 0; tx < richTextBox1.Text.Length - 1; tx++)
        {
                if (richTextBox1.Lines[tx] == richTextBox1.Lines[tx+1])
                {
                   // something like  richTextBox1.Lines[tx+1].RemoveAt(tx);
                   tx--;
                }
            }
        }
