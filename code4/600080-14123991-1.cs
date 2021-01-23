    public class PageableGridView : GridView, IPageableItemContainer
    {
         public PageableGridView() : base()
         {
              PagerSettings.Visible = false;
         }
         public event EventHandler<PageEventArgs> TotalRowCountAvailable;
         public int MaximumRows
         {
              get{ return this.PageSize; }
         }
         public int StartRowIndex
         {
              get{ return (this.PageSize * this.PageIndex); }
         }
         protected virtual void OnTotalRowCountAvailable(PageEventArgs e)
         {
              if (TotalRowCountAvailable != null)
                    TotalRowCountAvailable(this, e);
         }
         protected virtual void SetPageProperties(int startRowIndex, int maximumRows, bool dataBind) { }
    }
