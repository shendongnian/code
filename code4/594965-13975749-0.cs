    Control myControl;
    switch(x)
    {
      case TabType.Edit:
        myControl= ...;
        break;
      case TabType.View:
        myControl= ...;
        break;
      default:
        throw new Exception("Unexpected value of x: " + x);        
     }
     myPageView.Controls.Add(myControl);
