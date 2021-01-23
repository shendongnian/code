    public interface IManipControl
    {
        int ChartPropertyOwner { get; set; }
    }
 
    public class ManipButton : Button, IManipControl
    {
        public int ChartPropertyOwner{get;set;}
    }
