    public interface ISample
    {
        int SampleId { get; set; }
    }
    
    public class Sample1 : ISample
    {
        public int SampleId { get; set; }
        public Sample1() { }
    }
   
   
    public class Sample2 : ISample
    {
        public int SampleId { get; set; }
        public String SampleName { get; set; }
        public Sample2() { }
    }
   
    public class SampleGroup
    {
        public int GroupId { get; set; }
        public IEnumerable<ISample> Samples { get; set; }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            //Sample1 instance
            var sz = "{\"GroupId\":1,\"Samples\":[{\"SampleId\":1},{\"SampleId\":2}]}";
            var j = JsonConvert.DeserializeObject<SampleGroup>(sz, new SampleConverter<Sample1>());
            foreach (var item in j.Samples)
            {
                Console.WriteLine("id:{0}", item.SampleId);
            }
            //Sample2 instance
            var sz2 = "{\"GroupId\":1,\"Samples\":[{\"SampleId\":1, \"SampleName\":\"Test1\"},{\"SampleId\":2, \"SampleName\":\"Test2\"}]}";
            var j2 = JsonConvert.DeserializeObject<SampleGroup>(sz2, new SampleConverter<Sample2>());
            //Print to show that the unboxing to Sample2 preserved the SampleName's values
            foreach (var item in j2.Samples)
            {
                Console.WriteLine("id:{0} name:{1}", item.SampleId, (item as Sample2).SampleName);
            }
            Console.ReadKey();
        }
    }
