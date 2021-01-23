    public enum SourceStatus
    {
        Draft,
        Submitted,
        Deleted
    }
    public enum DestinationStatus
    {
        Step1,
        Step2,
        Step3
    }
    public class SourceObj
    {
        public SourceStatus Status { get; set; }
    }
    public class DestinationObj
    {
        public DestinationStatus Status { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Static APi style - this is obsolete now. From Version 5.0 onwards    this will be removed.
            SourceObj mySrcObj = new SourceObj();
            mySrcObj.Status = SourceStatus.Deleted;
            
            Mapper.CreateMap<SourceStatus, DestinationStatus>();
            Mapper.CreateMap<SourceObj, DestinationObj>();
            DestinationObj myDestObj = Mapper.Map<SourceObj, DestinationObj>(mySrcObj);
            //New way of doing it
            SourceObj mySrcObj2 = new SourceObj();
            mySrcObj2.Status = SourceStatus.Draft;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SourceObj, DestinationObj>();
            });
            IMapper mapper = config.CreateMapper();
            var source = new SourceObj();
            var dest = mapper.Map<SourceObj, DestinationObj>(source);
        }
    }
