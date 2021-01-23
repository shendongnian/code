    public class StackOverflow_18127665
    {
        public class WebAPINotificationAttribute : Attribute
        {
            public Type Type { get; set; }
            public string Group { get; set; }
        }
        public class CSensor { }
        public interface INotification { }
        public interface IOpSerializable { }
        public interface IBPMPackagedNotification { }
        public interface ILanNotification { }
        public interface ISensNotification { }
        [Serializable]
        [WebAPINotification(Type = typeof(CSensor), Group = "Sensor")]
        public class SensorsStateModeNotification : SensorNotification, IBPMPackagedNotification { }
        public abstract class SensorNotification : BasicLanNotification, ISensNotification { }
        [Serializable]
        public class BasicLanNotification : BasicNotification, ILanNotification { }
        [Serializable]
        public abstract class BasicNotification : INotification, ISerializable, IOpSerializable
        {
            long m_sentAt;
            ENotificationGateway m_NotifyGateway;
            [JsonIgnore]
            public long SentAt
            {
                get
                {
                    return m_sentAt;
                }
                set
                {
                    m_sentAt = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            [JsonIgnore]
            public ENotificationGateway NotificationGateway
            {
                get
                {
                    return m_NotifyGateway;
                }
                set
                {
                    m_NotifyGateway = value;
                }
            }
            #region ISerializable Members
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                // Comment the lines below not to have this serialized
                info.AddValue("NotificationGateway", this.NotificationGateway);
                info.AddValue("SentAt", this.SentAt);
            }
            #endregion
        }
        public enum ENotificationGateway { First, Second }
        public static void Test()
        {
            BasicNotification msg = new BasicLanNotification
            {
                SentAt = 123,
                NotificationGateway = ENotificationGateway.First
            };
            var str = JsonConvert.SerializeObject(
                msg,
                Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
            Console.WriteLine(str);
        }
    }
