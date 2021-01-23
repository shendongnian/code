        private int _inputNumber = 0;
        private void Form_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar)) return;
            _inputNumber = 10*_inputNumber + Int32.Parse(e.KeyChar.ToString());
            ReformatOutput();
        }
        private void ReformatOutput()
        {
             myOutput.Text = String.Format("{0:0.00}", (double)_inputNumber / 100.0);
        }
