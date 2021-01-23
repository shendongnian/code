    using System.Windows.Forms;
    ...
    var form = (Form)Form.FromHandle(window.Handle);
    form.KeyPress += form_KeyPress;
    
    ...
    private void form_KeyPress(Object sender, KeyPressEventArgs e)
    {  
        Console.WriteLine(e.KeyChar);
        e.Handled = true;
    }
