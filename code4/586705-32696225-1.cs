    private void textBox1_TextChanged(object sender, EventArgs e)
            {
                foreach (string line in textBox1.Lines)
                {
                    if (line.Length > 60)
                    {
                        textBox1.Undo();
                    }
                }
                textBox1.ClearUndo();
            }
