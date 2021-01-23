    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        var category = listBox1.Items[e.Index] as Categorie;
        Color backColor = Color.Green;
        if (category.ID == someID)
        {
            backColor = Color.Gray;
        }
        // draw back color and text 
    }
