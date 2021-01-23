    using Sitecore.Data.Items;    
    // The SecurityDisabler is required which will overrides the current security model, allowing the code
    // to access the item without any security. 
    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
      // Get the master database
      Sitecore.Data.Database master = Sitecore.Data.Database.GetDatabase("master");
      // Get the template for which you need to create item
      Items.TemplateItem template = master.GetItem("/sitecore/templates/Sample/Sample Item");
     
      // Get the place in the site tree where the new item must be inserted
      Item parentItem = master.GetItem("/sitecore/content/home");
     
      // Add the item to the site tree
      Item newItem = parentItem.Add("NameOfNewItem", template);
     
      // Set the new item in editing mode
      // Fields can only be updated when in editing mode
      // (It's like the begin transaction on a database)
      newItem.Editing.BeginEdit();
      try
      {
        // Assign values to the fields of the new item
        newItem.Fields["Title"].Value = "NewValue1";
        newItem.Fields["Text"].Value = "NewValue2";
     
        // End editing will write the new values back to the Sitecore
        // database (It's like commit transaction of a database)
        newItem.Editing.EndEdit();
      }
      catch (System.Exception ex)
      {
        // Log the message on any failure to sitecore log
        Sitecore.Diagnostics.Log.Error("Could not update item " + newItem.Paths.FullPath + ": " + ex.Message, this);
     
        // Cancel the edit (not really needed, as Sitecore automatically aborts
        // the transaction on exceptions, but it wont hurt your code)
        newItem.Editing.CancelEdit();
      }
    }
