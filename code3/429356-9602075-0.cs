        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.B || ...)
                e.IsInputKey = true;
            else
                e.IsInputKey = false;
        }
