        private void button10_Click(object sender, EventArgs e)
        {
            if (arreglo.Count < 10)
            {
                arreglo.Add(textBox1.Text);
                this.textBox1.Clear();
                this.textBox1.Focus();
            }
            else
                button10.Enable = false;
        }
