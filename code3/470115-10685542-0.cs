    var listAddresses = GetAddresses().ToList(); 
            List<ListItem> addressList = new List<ListItem>();
            foreach (IAddress address in listAddresses )
                {
                    ListItem items = new ListItem();
                    items.Text = address.Name;
                    items.Value = address.ID;
                    addressList .Add(items);
                    
                   
                }
            }
        return Json(new JsonResult { Data = new SelectList(addressList, "Value", "Text") }, JsonRequestBehavior.AllowGet);
