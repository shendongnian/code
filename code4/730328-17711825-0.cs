    private void InPutBoxMethod()
        {
            // split text into lines
            var lines = textBox1.Text.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
            // loop through all lines and check for errors
            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                System.Console.WriteLine("'{0}'", line);
                if ((line.StartsWith("W") && line.EndsWith("0")))
                {
                    MessageBox.Show("These are errors in line " + index + ": " + line);
                    break;
                }
            }
        }
