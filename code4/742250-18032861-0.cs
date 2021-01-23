    //well then you can declare the interface as:
    public interface ITextControl{
     string TextValue{get;set}
    }
    //and in your code:
    public partical class whateveryourcontrolname:UserControl,ITextControl
    {
    /..../
    public string TextValue{
     get{
      return this.Text;
     }
    set{
     this.Text=value;
     }
    }
    }
    //and your method:
    void AddMethod(ITextControl txtCtrl){
     txtCtrl.TextValue="Yes";
    }
