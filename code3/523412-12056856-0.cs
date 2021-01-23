        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter && GetKeyState(Keys.Enter) < 0) {
                Console.WriteLine("Really down");
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(Keys key);
