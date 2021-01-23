    void myButtonClicked(object sender, EventArgs e)
    {
        if (MyButtonClicked != null)
        {
            MyButtonClicked(this, new EventArgs());
        }
    }
