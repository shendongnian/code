    listview1.Columns.Add("Col1");
    listview1.Columns.Add("Col2");
    foreach(ArticleDetails ad in myCollection)
    {
       var row = new ListViewItem(ad.Article.Name);
       row.Tag = ad; // You can use this to store your object
       row.SubItems.Add(ad.Article.Price);
    }
    listview1.View = View.Details;
    
    
    private void btnDelete_Click(object sender, EventArgs e)
    {
       var selected = (CustomDataType)listview1.SelectedItems[0].Tag;
    }
