    protected void gridLocation_ItemDataBound(object sender, GridItemEventArgs e)
        {
                if (e.Item.IsInEditMode)
                {
                    GridEditableItem item = (GridEditableItem)e.Item;
                    if (!(e.Item is IGridEditableColumn))
                    {
                        RadComboBox combo = (RadComboBox)item.FindControl("dropdwnCountry");
                        LoadCountries(combo);
                    }
                }
        }
    protected void LoadCountries(RadComboBox combo)
        {
            //your defn goes here
        }
