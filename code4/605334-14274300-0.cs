    public class Controller
    {
        [Key]
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public virtual List<ControllerDevice> Devices { get; set; }
    }
