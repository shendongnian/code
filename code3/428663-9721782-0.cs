    SPSecurity.RunWithElevatedPrivileges(() =>
                         {
                             using (var site = new SPSite(CurrentWeb.Site.Url))
                             {
                                 using (var web = site.OpenWeb(CurrentWeb.ID))
                                 {
                                     web.AllowUnsafeUpdates = true;
                                     SPList userInfo = web.Site.RootWeb.Lists["User Information List"];
                                     SPListItem userItem = userInfo.Items.GetItemById(_SelectedUser.ID);
                                     userItem["Work phone"] = tbPhone.Text;
                                     userItem["Work e-mail"] = tbEmail.Text;
                                     userItem["company"] = tbCompany.Text;
                                     userItem.Update();
                                 }
                             }
                         });
