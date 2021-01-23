    public static DialogResult ShowMessage(Form Parent, string Text, string Caption, MessageBoxButtons Buttons, MessageBoxIcon Icon, MessageBoxDefaultButton DefaultButton)
    {
        if (Parent != null && Parent.InvokeRequired)
            return (DialogResult) Parent.Invoke(((Func<DialogResult>))(() => MessageBox.Show(Text, Caption, Buttons, Icon, DefaultButton)));
        else
            return (MessageBox.Show(Text, Caption, Buttons, Icon, DefaultButton));
    }
