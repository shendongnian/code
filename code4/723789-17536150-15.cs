public class MyObject : Dictionary<string, object>{}
public class MyPlaceHolder
{
    public MyPlaceHolder(string index, MyObject target)
    {
        Index = index;
        TargetObject = target;
    }
        
    public string Index {get; private set;}
    public MyObject TargetObject {get; private set;}
    public object Value 
    {
        get
        {   
           return TargetObject[Index];
         }
        set
        {    
            var prev = TargetObject[Index];
            TargetObject[Index] = value;
            _prevVals.Push(prev);
        }
    }
    private Stack<object> _prevVals = new Stack<object>();
        
    public bool UndoSet()
    { 
        if(!_preVals.Count() == 0)
        {
            Value._prevVals.Pop();
            return true;
        }
        return false;
    }
}
