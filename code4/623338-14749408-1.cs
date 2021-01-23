     private void SetText(TextBox txt, string text)
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
