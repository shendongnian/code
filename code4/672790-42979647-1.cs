    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
    MessageBoxIcon icon = MessageBoxIcon.Error;
    string message = Resources.ResourceManager.GetString("MESSAGE");
    string caption = Resources.ResourceManager.GetString("TITLE");
    DialogResult result;
    Form form;
    using (form = new Form())
    {
        form.TopMost = true;
        result = MessageBox.Show(form, caption, message, buttons, icon);
    }
    if (result == DialogResult.Yes)
    {
        // do something with the result
    }
