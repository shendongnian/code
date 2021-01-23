    public class DionysusTextBox : TextBox, IDionysusControl
    {
        static DionysusTextBox()
        {   
            //For the IsReadOnly dependency property    
            IsReadOnlyProperty.OverrideMetadata(
                //On the type DionysusTextBox
                typeof(DionysusTextBox), 
                //Redefine default behavior           
                new FrameworkPropertyMetadata(
                    //Default value, can also omit this parameter
                    null,
                    //When IsReadOnly changed, this is executed 
                    new PropertyChangedCallback(
                        (dpo, dpce) =>
                        {
                           //dpo hold the DionysusTextBox instance on which IsReachOnly changed
                           //dpce.NewValue hold the new value of IsReadOnly
    
                           //Run logic to set the background here, you are on the UI thread.
                           
                           //Example of setting the BorderBrush from ARGB values:
                           var dioBox = dpo as DionysusTextBox;
                           //Should always be true, of course, it's just my OCD ;)
                           if (dioBox != null)                  
                           {
                              dioBox.BorderBrush = 
                                  ColorConverter.ConvertFromString("#FFDDDDDD") as Color;
                           }
                        })));
        }
    
        
        public DionysusTextBox()
        {
          SetStyle();
        }
    }
