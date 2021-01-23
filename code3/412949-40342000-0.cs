    [DataContract]
    public class SerializableClass {
    	public Shapes Shape {get; set;} //Do not use the DataMemberAttribute in the public property
    	
    	[DataMember(Name = "shape")]
        private string ShapeSerialization // Notice the PRIVATE here!
        {
            get { return EnumHelper.Serialize(this.Shape); }
            set { this.Shape = EnumHelper.Deserialize<Shapes>(value); }
        }
    }
