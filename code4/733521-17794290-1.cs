    public class MySample : Sample{}
    
    public class MyExperiment : Experiment<MySample>{}
    
    MyExperiment me = new MyExperiment();
    me.AddSample(new MySample());
