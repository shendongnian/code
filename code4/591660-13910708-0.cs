      protected void Page_Load(object sender, EventArgs e){     
      foreach (ListViewItem item in lvStaffer.Items)
            {
               Control_ResourceListViewControl resourceListViewControlItem =
            (Control_ResourceListViewControl)e.Item.FindControl("ResourceListViewControlItem");
            if (resourceListViewControlItem != null)
            {
               // Each item in lvStaffer contains an instance of the          ResourceListViewControl object.
              // Each object is a subscriber of the ResourceReassigned event.
               resourceListViewControlItem.ResourceReassigned += new   EventHandler(lvStaffer_ResourceReassigned);
            }
           }
            
}
