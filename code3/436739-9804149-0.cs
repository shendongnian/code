    protected void Button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(string.Format("txt={0}\r\ntv={1}\r\nsn={2}",
                                      txtRetailCustomerGroup,
                                      TreeView1,
                                      TreeView1 == null ? "." : TreeView1.SelectedNode));
        txtRetailCustomerGroup.Text = TreeView1.SelectedNode.Parent.ToString();
    }
