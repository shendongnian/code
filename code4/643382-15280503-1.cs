    [HttpPost]
    public ActionResult SendItems(MyModel model)
    {
        foreach (var item in model.Items.Where(item => item.IsSelected))
        {
            m_ListInventoryToSend.Add(item);
        }
        
        //rest of your post action
    }
