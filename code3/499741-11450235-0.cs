        for (int a = 0; a < 10; a++)
        {
            txtblck.Text = txtblk.Text + a.ToString();
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);
        }
