    [DataContract]
    public class MJPEGCamera : Camera
    {
    }
    [DataContract]
    public class H264Camera : Camera
    {     
    }
    [DataContract]
    public class Camera
    {
        [DataMember]
        public string cameraName { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public string format { get; set; }
        [DataMember]
        public string archiveDaysUrl { get; private set; }
        [DataMember]
        public string archiveHoursUrl { get; private set; }
    }
