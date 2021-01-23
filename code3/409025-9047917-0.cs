    protected void Page_Load(object sender, EventArgs e)
    {
        strings = new StringBuilder[] { fiction, non_fiction, self_help };
    }
    protected void Submit_btn_Click(object sender, EventArgs e)
    {
        strings[Cat_DropDownList.SelectedIndex].Append("Title: " + Titletxt.Text + " | " + "Description: " + Descriptiontxt.Text + " | " + "Price: " + Pricetxt.Text + " | " + "Quantity: " + Quantitytxt.Text);
    }
