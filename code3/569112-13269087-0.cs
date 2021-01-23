    public class DeviceNotificationMessages
    {
        public DeviceNotificationMessages()
        {
            CreateDate = DateTimeOffset.Now;
        }
        [Column(Order = 0), Key, ForeignKey("NotificationMessage")]
        public int NotificationMessageId { get; set; }
        public virtual NotificationMessage NotificationMessage { get; set; }
        [Column(Order = 1), Key, ForeignKey("Device")]
        public int DeviceID { get; set; }
        public virtual Device Device { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
