    public class GridView : System.Web.UI.WebControls.GridView
    {
       protected override void OnSorted(EventArgs e)
       {
          string imgArrowUp = ...;
          string imgArrowDown = ...;
          
          foreach (DataControlField field in this.Columns)
          {
             // strip off the old ascending/descending icon
             int iconPosition = field.HeaderText.IndexOf(@" <img border=""0"" src=""");
             if (iconPosition > 0)
                field.HeaderText = field.HeaderText.Substring(0, iconPosition);
    
             // See where to add the sort ascending/descending icon
             if (field.SortExpression == this.SortExpression)
             {
                if (this.SortDirection == SortDirection.Ascending)
                   field.HeaderText += imgArrowUp;
                else
                   field.HeaderText += imgArrowDown;
             }
          }
    
          base.OnSorted(e);
       }
    }
