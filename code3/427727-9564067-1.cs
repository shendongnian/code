    [DataContract]
    internal class GISData
    {
        [DataMember]
        public string href;
        
        [DataMember]
        public int width;
        [DataMember]
        public int height;
        [DataMember]
        public GISDataExtent extent;
        [DataMember]
        public string scale;
    }
    [DataContract]
    internal class GISDataExtent
    {
        [DataMember]
        public string xmin;
        [DataMember]
        public string ymin;
        [DataMember]
        public string xmax;
        [DataMember]
        public string ymax;
        [DataMember]
        public GISDataExtentSpatialReference spatialReference;
    }
    [DataContract]
    internal class GISDataExtentSpatialReference
    {
        [DataMember]
        public string wkid;
    }
