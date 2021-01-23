        public static bool _Invoked;
        Form2 f2 = new Form2();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!_Invoked)
            {
                _Invoked = true;
                f2.Show();
            }
            else if (_Invoked)
            {
                f2.BringToFront();
                _Invoked = false;
            }
        }
