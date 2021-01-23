    private void SetCursorLine(TextBox textBox, int line)
            {
                int seed = 0;
                int pos = -1;
                line -= 1;
    
                if(line == 0)
                {
                    pos = 0;
                }
                else
                {
                    for (int i = 0; i < line; i++)
                    {
                        pos = textBox.Text.IndexOf(Environment.NewLine, seed) + 2;
                        seed = pos;
                    }
                }
                
                if(pos != -1)
                {
                    textBox.Select(pos, 0);
                }
                
            }
