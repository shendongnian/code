    var root = JsonConvert.DeserializeObject<RootObject>(qstatusOutput);
    foreach (var job in root.jobs)
    {
        Console.WriteLine(job.timeleft);
    }
    public class Job
    {
        public string timeleft { get; set; }
        public double mb { get; set; }
        public string msgid { get; set; }
        public string filename { get; set; }
        public double mbleft { get; set; }
        public string id { get; set; }
    }
    public class RootObject
    {
        public string have_warnings { get; set; }
        public bool pp_active { get; set; }
        public int noofslots { get; set; }
        public bool paused { get; set; }
        public string pause_int { get; set; }
        public double mbleft { get; set; }
        public double diskspace2 { get; set; }
        public double diskspace1 { get; set; }
        public List<Job> jobs { get; set; }
        public string speed { get; set; }
        public string timeleft { get; set; }
        public double mb { get; set; }
        public string state { get; set; }
        public string loadavg { get; set; }
        public double kbpersec { get; set; }
    }
