            string formID = ConfigurationManager.AppSettings["FormDataUploadID"].ToString(); 
           
            List<GridFilter> args = new List<Sitecore.Web.UI.Grids.GridFilter>();
            args.Add(new GridFilter("storageName", string.Empty, GridFilter.FilterOperator.Contains));
            args.Add(new GridFilter("dataKey", formID, GridFilter.FilterOperator.Contains));
            var submits = Sitecore.Forms.Data.DataManager.GetForms().GetPage(new PageCriteria(0, 0x7ffffffe), null, args);
            /// Create a Collection to Loop
            List<IForm> formlist = submits.ToList();
            /// Loop all forms from Database and delete each entry.
            foreach (IForm frm in formlist)
            {
                Sitecore.Forms.Data.DataManager.DeleteForms(new Sitecore.Data.ID(frm.FormItemId), frm.StorageName);
            }
