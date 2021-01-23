        private delegate void SetControlTextDelegate(TextBox TB, string txt);
        private void SetControlText(TextBox TB, string txt)
        {
            if (TB.InvokeRequired)
            {
                TB.Invoke(new SetControlTextDelegate(SetControlText), new object[] { TB, txt });
            }
            else
            {
                TB.AppendText(txt + Environment.NewLine);
            }
        }
