    public class NotificationPropertyResolver : DefaultContractResolver
        {
            public NotificationPropertyResolver()
            {
                IgnoreSerializableAttribute = true;
                IgnoreSerializableInterface = true;
            }
           
        }
