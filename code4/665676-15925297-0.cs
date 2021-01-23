    async void Button_Click()
    {
    for (int i = 0; i < 100; i++)
    {
    textbox.Text = i.ToString();
    await Task.Delay(1000);
    }
    }
