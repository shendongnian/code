    // removing a cssClass
    protected String removeCssClass(string cssClass, string toRemove)
    {
        return String.Join(" ", cssClass.Split(' ').Except(new[] {toRemove}).ToArray());
    }
    void lbl_Click(object sender, EventArgs e)
    {
        // resetting all selected items
        plcPaging.Controls
          .OfType<Label>()
          .Where(l => l.ID.StartsWith("lnkPage") && l.CssClass.Split(' ').Contains("selectedClassName")).ToList()
          .ForEach(l => l.CssClass = removeCssClass(l.CssClass, "classname"));
        LinkButton lnk = sender as LinkButton;
        // setting selected item
        lnk.CssClass = "classname";
        int currentPage = int.Parse(lnk.Text);
        int take = currentPage * 15;
        int skip = currentPage == 1 ? 0 : take - 15;
        FetchData(take, skip);
    }
