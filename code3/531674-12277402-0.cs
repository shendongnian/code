    var button = new Button();
    try
    {
        button.Text = "Button 1";
        button.Click += (sender, e) => System.Diagnostics.Process.Start(targetURL);
        //Or if you don't want to use a lamda and would rather have a method;
        //button.Click += MyButton_Click;
        Controls.Add(button);
    }
    catch
    {
        button.Dispose();
        throw;
    }
    //Only needed when not using a lamda;
    void MyButton_Click(Object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start(targetURL);
    }
