    1  private List<WireObjectCoordinates> _coordinateslist = new List<WireObjectCoordinates>();  
    2  public List<WireObjectCoordinates> CoordinatesList  
    3  {  
    4      get { return _coordinateslist; } // <<< your breakpoint here
    5  }  
    6
    7  private void button8_Click(object sender, EventArgs e)   
    8  {   
    9      if (buttonLockMode == true)   
    10     {
    11         // ...
    12         List<WireObjectCoordinates>  temp = wireObjectAnimation1.CoordinatesList; // <<< my breakpoint here
    13         temp.Add(wireObjectCoordinates1);
    14     }   
    15     else   
    16     {   
    17         // ...
