        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            sc.Close();
            sc.Dispose();
            sc = null;
            //kill is unnecessary.  I'd just stick with app exit.
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
