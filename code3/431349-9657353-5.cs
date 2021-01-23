    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategories.SelectedValue == "")
        {
            ddlProducts.Items.Clear();
            ddlProducts.SelectedIndex = -1;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lblSelectedValues.Text = "You selected Category:" + ddlCategories.SelectedItem.Text + " & prodcut:" + ddlProducts.SelectedItem.Text;
    }
