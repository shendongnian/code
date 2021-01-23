    public class MailItemWrapper
    {
      public MailItem item;
      public MailItemWrapper(MailItem OutlookItem)
      {
        item = OutlookItem;
        item.PropertyChange += new System.EventHandler(PropertyChangeHandler);
      }
      private PropertyChangeHandler(string Name)
      {
        MessageBox.Show(string.Format("Property named {0} changed on item {1}", name, item.Subject))
      }
    }
