    class CellBase 
    {
      string Name {get; set;}
      string Value {get; set;}
    }
    
    class DataCell : CellBase 
    {
      //Data specific properties
    }
    
    class LinkCell : CellBase
    {
      linkObject cellValue = new linkObject("linkString", "linkHREF", "linkOnClick");
      //linkObject is a simple class with only 3 strings as well
    }
    
    //Now create your list with
    
    List<CellBase> cells
