    [DllImport("inpout32.dll", EntryPoint = "Inp32")] 
    public static extern int Input(int adress); 
 
    struct Sample 
    {
        public int Value;
        public int Milliseconds;
    };
    private void button1_Click(object sender, EventArgs e) 
    { 
        TimeSpan duration = TimeSpan.FromSeconds(5);
        TimeSpan samplePeriod = TimeSpan.FromMilliseconds(50);
        var samples = GetInputSamples(889, duration, samplePeriod);
        SaveSamplesCSV(samples, "test.csv");
    } 
 
    private static List<Sample> GetInputSamples(int inputPort, TimeSpan duration, TimeSpan samplePeriod)
    { 
        List<Sample> samples = new List<Sample>();
        var oldPriority = Thread.CurrentThread.Priority;
        try
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            DateTime start = DateTime.Now;
            while (DateTime.Now - start < duration)
            {
                int value = Input(inputPort); 
                TimeSpan timestamp = DateTime.Now - start;
                samples.Add(new Sample() { Value = value, Milliseconds = (int)timestamp.TotalMilliseconds });
                Thread.Sleep(samplePeriod);
            }
        }
        finally
        {
            Thread.CurrentThread.Priority = oldPriority;
        }
        return samples;
    }
    private static void SaveSamplesCSV(List<Sample> samples, string fileName)
    {
        using (StreamWriter writer = File.CreateText(fileName))
        {
            writer.WriteLine("Sample, SampleTime");
            foreach (var sample in samples)
            {
                writer.WriteLine("{0},{1}", sample.Value, sample.Milliseconds);
            }
        }
    }
