    [Flags]
    public enum NotificationDeliveryType
    {
        InSystem = 1,
        Email = 2,
        Text = 4
    }
    public class MyViewModel
    {
        public IEnumerable<NotificationDeliveryType> Notifications { get; set; }
    }
