        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("You pressed " + e.KeyCode);
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                //Do Something if the 0 key is pressed (includes Num Pad 0)
            }
        }
