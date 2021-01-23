    public static void doit(string a, string b)
    {
        Form1 F1 = Application.openForms[0] as Form1;
        if(F1.InvokeRequired)
            F1.Invoke(new MethodInvoker(delegate() { F1.Text = a + b; });
        else
            F1.Text = a + b;
    }
            
