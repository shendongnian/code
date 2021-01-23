             PageSize = maximumRows;
             int newPageIndex = (startRowIndex / PageSize);
             if (PageIndex != newPageIndex)
             {
                 OnPageIndexChanging(new GridViewPageEventArgs(newPageIndex));
                 PageIndex = newPageIndex;
                 OnPageIndexChanged(EventArgs.Empty);
             }
}
        RequiresDataBinding = databind;
