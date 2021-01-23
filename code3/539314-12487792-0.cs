    public interface IMenu{
    string functionFoo();
    }
    
    public class Menu54 : IMenu {
    public string Text { get; set;}
    public string functionFoo(){
    return Text;
    }
