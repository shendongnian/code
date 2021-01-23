    for (int i = 0; i < gridView.Columns.Count; i++) 
    {
      TableCell tableCell = gridViewRow.Cells[i];
      System.Web.UI.WebControls.Image img;
      sortDirectionImageControl = new System.Web.UI.WebControls.Image();
      string imageUrl = "~/Images/Myimage.jpg"; 
      img.ImageUrl = imageUrl;
      img.Style.Add(HtmlTextWriterStyle.MarginLeft, "10px");
      tableCell.Wrap = false;
      tableCell.Controls.Add(img);
    }
