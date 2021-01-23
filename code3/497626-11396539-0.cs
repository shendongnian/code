    public event EventHandler ButtonClicked;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if(this.ButtonClicked != null)
        {
            this.ButtonClicked(this, EventArgs.Empty);
        }
    }
