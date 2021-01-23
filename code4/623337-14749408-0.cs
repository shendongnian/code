     private void SetText(string text, TextBox txt)
        {
            if (txt.InvokeRequired)
            {
               Invoke((MethodInvoker)(() => txt.Text = text));
            }
            else
            {
                txt.Text = text;
            }
        }
