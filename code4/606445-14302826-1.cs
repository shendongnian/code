    private void button1_Click(object sender, EventArgs e)
    {
        if (enumerator.MoveNext())
        {
            label1.Text = enumerator.Current.Categorie;
        }
    }
