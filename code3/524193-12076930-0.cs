    TextBox tbox = null;
    private void tbox1_TextChanged(object sender, EventArgs e)
    {
        tbox = sender as TextBox;
        var8 = Convert.ToDouble(tbox.Text);
    }
    private void button3_Click(object sender, EventArgs e)
    {
        result2 = var8 * 2;
        if (tbox!=null)
            tbox.Text = result2.ToString();
    }
