    public class NotificationMessageDevice
    {
        [Column(Order = 0), Key, ForeignKey("NotificationMessage")]
        public int NotificationMessage_ID { get; set; }
    
        [Column(Order = 1), Key, ForeignKey("Device")]
        public int Device_ID { get; set; }
        [Column(Order = 2), Key, ForeignKey("Device")]
        public string Device_UDID { get; set; }
        [Column(Order = 3), Key, ForeignKey("Device")]
        public string Device_ApplicationKey { get; set; }
    
        public virtual Device Device { get; set; }
        public virtual NotificationMessage NotificationMessage { get; set; }
    }
