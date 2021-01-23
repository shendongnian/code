    [DataContract(Name = "Alarms")]
    public class Alarms
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "PatientId")]
        public int PatientId { get; set; }
        [DataMember(Name = "AlarmType")]
        public string AlarmType { get; set; }
        [DataMember(Name = "AlarmDate")]
        public DateTime AlarmDate { get; set; }
        [DataMember(Name = "AlarmName")]
        public string AlarmName { get; set; }
        [DataMember(Name = "IsEnabled")]
        public bool IsEnabled { get; set; }
    }
