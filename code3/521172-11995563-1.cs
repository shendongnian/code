    public static Form globalForm;
    void Main()
    {
        globalForm = new Form();
        globalForm.Show();
        globalForm.Hide();
        // Spawn threads here
    }
    void ThreadProc()
    {
        myForm form = new myForm();
        globalForm.Invoke((MethodInvoker)delegate() {
            form.Text = "my text";
            form.Show();
        });
    }
