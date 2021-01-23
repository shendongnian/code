    private void AddButton()
    {
        Button button = new Button(this);
        button.Click += Button_Click;
        // add text and other properties
        main.AddView(button);
    }
    
    private void Button_Click(object sender, EventArgs e)
    {
        Button button = (sender as Button);
        // use clicked button e.g. Console.WriteLine("Selected = {0}", button.Text);
    }
