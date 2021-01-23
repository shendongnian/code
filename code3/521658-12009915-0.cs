    /// <summary>
       /// An item was added.
       /// </summary>
       public override void ItemAdded(SPItemEventProperties properties)
       {
           base.ItemAdded(properties);
           SPListItem item = properties.ListItem;
           if (item["Name"] == null)
               return; //or better yet, log
           
           string oldFileName = item["Name"].ToString();
           SPQuery query = BuildArbitraryQuery(properties.List, "Created By", properties.UserDisplayName, true);
           int count = properties.List.GetItems(query).Count;
           int positionOfPeriod = oldFileName.LastIndexOf(".");
           string fileName = oldFileName.Substring(0, positionOfPeriod);
           string fileExtension = oldFileName.Substring(positionOfPeriod);
           string newFileName = fileName + "-xx" + count.ToString() + fileExtension;
           item["Name"] = newFileName;
           try
           {
               properties.Web.AllowUnsafeUpdates = true;
               EventFiringEnabled = false;
               item.Update();
           }
           finally
           {
               properties.Web.AllowUnsafeUpdates = false;
               EventFiringEnabled = true;
           }
       }
       /// <summary>
       /// Builds an arbitrary SPQuery which filters by a single column value.
       /// </summary>
       /// <param name="list">The list you will run the query against.</param>
       /// <param name="columnDisplayName">The Display Name of the column you want to filter.</param>
       /// <param name="value">The value to filter against.</param>
       /// <returns>A new SPQuery object ready to run against the list.</returns>
       public static SPQuery BuildArbitraryQuery(SPList list, string columnDisplayName, string value, bool deepSearch)
       {
           if (list == null)
               throw new ArgumentNullException("You cannot pass a null list to Helper.BuildArbitraryQuery.");
           if (!list.Fields.ContainsField(columnDisplayName))
               throw new ArgumentException("The SharePoint List \"" + list.Title + "\" does not contain the Field \"" + columnDisplayName + "\".");
           string internalName = list.Fields[columnDisplayName].InternalName;
           SPQuery query = new SPQuery();
           query.Query = "<Where><Eq><FieldRef Name=\"" + internalName + "\"/><Value Type=\"Text\">" + value + "</Value></Eq></Where>";
           if (deepSearch)
               query.ViewAttributes += "Scope='RecursiveAll'";
           return query;
       }
