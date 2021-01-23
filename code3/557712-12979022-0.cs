        private void button2_Click(object sender, EventArgs e)
        {
            // richTextBox1.Lines is a string[], which works with IEnumerable<string> (per line)
            var form = new Form1(richTextBox1.Lines);
            // Just show the form
            form.Show(); 
        }
