     public override void ItemUpdating(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);
            if (properties.ListTitle == "TestUsers")
            {
                SPWeb web = properties.OpenWeb();
                SPList list = web.Lists[properties.ListTitle];
                SPListItem litemUser = list.GetItemById(properties.ListItemId);
                SPList objFeatureList = web.Lists["TestGroups"];
                SPQuery objParentQuery = new SPQuery();
                string user = properties.AfterProperties["User"].ToString();
 
                //in Caml query just find it out listitem which contain Users and than update its listitem.
                objParentQuery.Query = "<Where><Eq><FieldRef Name='Check_x0020_it_x0020_out'/><Value Type='Integer'>"+You should set Userid in Field From litemUser +"</Value></Eq></Where>";
                SPListItemCollection liitemcol = objFeatureList.GetItems(objParentQuery);
                foreach (SPListItem litemGroup in liitemcol)
                {
                    litemGroup["Group"] = litemUser["Group"];
                    litemGroup.Update();
                    // or if you want to using Workflow just startWorflow when item has match over here.
                }
            }
        }
