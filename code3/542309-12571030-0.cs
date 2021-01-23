    TableCell tc=new TableCell();  
    for (int j = 0; j < i; j++)
    {
        System.Web.UI.WebControls.Image rating = new  System.Web.UI.WebControls.Image();
        rating.ImageUrl = "~/Images/star.gif"; // no need for Server.MapPath
        rating.ID = j.ToString();
        rating.AlternateText = "No image";
        tc.Controls.Add(rating);
    }
