    // This class tracts changes to its entries
    public class BoolArray_Tracted{
      // Set up the data for which changes at specific indices must be tracted
      private bool[] _tractedBools;
      public bool this[int itemIndex]{
        get { return _tractedBools[itemIndex]; }
        set {
          // check if something really changed
          // not sure if you want this
          if(_tractedBools[itemIndex] != value){
          _tractedBools[itemIndex] = value;
          OnIndexChanged(itemIndex, value);// Raise an event for changing the data
          }
        }
      }
      
      // Constructor
      public BoolArray_Tracted(bool[] _tractedBools){
        this._tractedBools = _tractedBools;
      }
      
      // Set up the event raiser
      public delegate void IndexEventHandler(object sender, IndexEventArgs a);
      public event IndexEventHandler RaiseIndexEvent;
      
      // Raise an event for changing the data
      private void OnIndexChanged(int indexNumber, bool boolValue){
        if (RaiseIndexEvent != null)
          RaiseIndexEvent(this, new IndexEventArgs(indexNumber, boolValue));
      }
    }
    
    // This is class enables events with integer and boolean fields
    public class IndexEventArgs : EventArgs{
      public int Index{get; private set;}
      public bool Value{get; private set;}
      public IndexEventArgs(int _index, bool _value){
        Index = _index;
        Value = _value;
      }
    }
