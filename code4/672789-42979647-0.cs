    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
    MessageBoxIcon icon = MessageBoxIcon.Error;
    string message = Resources.ResourceManager.GetString("MESSAGE");
    string caption = Resources.ResourceManager.GetString("TITLE");
    DialogResult result = null;
    Form form;
    using (form = new Form())
    {
        form.TopMost = true;
        MessageBox.Show(form, caption, message, buttons, icon);
    }
    if (result == DialogResult.Yes)
    {
        // do something with the result
    }
