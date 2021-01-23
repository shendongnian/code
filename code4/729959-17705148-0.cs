    //don't forget to attach this event handler, either in markup 
    //on the GridView control, in code (say, in the Page_Init event handler.)
    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
      //HtmlImage gives you a plain-vanilla <img> tag in the HTML.  
      //If you need to handle some server side events (such as Click)
      //for the image, use a System.Web.UI.WebControls.Image control
      //instead.
      HtmlImage img = new HtmlImage() { Src = "path/to/image.jpg" };
      e.Row.Cells[1].Controls.Add(img);
    }
