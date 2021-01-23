    protected void btnNext_Click(object sender, EventArgs e)
    {
      MyForm2 x = new MyForm2();
      x.Query = "My Query";   // here "Query" is your custom public string variable on form2
      x.Show()
    }
