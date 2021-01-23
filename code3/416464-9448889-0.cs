    public void UpdateControlText(XtraForm Form, string ControlToUpdate, string ControlValue)
    {
        if (Form.Controls[ControlToUpdate].InvokeRequired)
        {
            try
            {
                Form.Controls[ControlToUpdate]
                    .Invoke(() => Form.Controls[ControlToUpdate].Text = ControlValue.Translate());
            }
            catch (Exception x)
            {
                UpdateStatus(string.Format("ControlText1: {0} ControlToUpdate={1}ControlText={2}", 
                    x.Message, ControlToUpdate, ControlValue));
            }
        }
    }
