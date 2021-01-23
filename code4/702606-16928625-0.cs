    SPWeb   web   = SPContext.Current.Web;
    SPList  list  = web.Lists[LISTNAME];
    SPQuery query = new SPQuery
    {
        Query = @"<Where>
                     <Contains>
                        <FieldRef Name='Field' />
                        <Value Type='Text'>your value</Value>
                     </Contains>
                  </Where>"
    };
    SPListItemCollection items = list.GetItems(query);
