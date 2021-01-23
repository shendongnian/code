    // In MyForm
    public void SetTitle(string text)
    {
        this.Text = text;
    }
    // Call the Method
    MyForm newForm = new MyForm();
    newForm.Show();
    newForm.SetTitle("Form2");
