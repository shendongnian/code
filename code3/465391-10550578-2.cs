    public class Pipe
    {
        public string Name { get; set; }
        public float Length { get; set; }
    }
    
    public class PipePile
    {
        public string PipeType { get; set; }
        public List<Pipe> Pipes { get; set; }
    
        public PipePile(string pipeType, List<Pipe> pipes)
        {
            PipeType = pipeType;
            Pipes = pipes;
        }
    
        public PipePile(): this("", new List<Pipe>())
        {
        }
    }
