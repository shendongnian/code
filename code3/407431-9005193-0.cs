    new System.Threading.Thread(() =>
    {
        for(int i = 0; i < 10000; i++)
        {
            sb.AppendLine(DateTime.Now.ToString());
            Invoke((Action)(() => 
            {
                txtArea.Text = sb.ToString();
                txtArea.SelectionStart = txtArea.Text.Length;
                txtArea.ScrollToCaret();
            }));
        }
    }).Start();
