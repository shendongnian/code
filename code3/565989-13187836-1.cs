    // two fields to keep the previous values of Text and SelectedIndex
    private string _oldText = string.Empty;
    private int _oldIndex = -2;
    .
    // somewhere in your code where you subscribe to the events
    this.ComboBox1.SelectedIndexChanged += 
    new System.EventHandler(ComboBox1_SelectedIndexChanged_AND_TextChanged);
    this.ComboBox1.TextChanged+= 
    new System.EventHandler(ComboBox1_SelectedIndexChanged_AND_TextChanged);
    .
    .
    /// <summary>
    ///  Shared event handler for SelectedIndexChanged and TextChanged events.
    ///  In case both index and text change at the same time, index change
    ///  will be handled first.
    /// </summary>
    private void ComboBox1_SelectedIndexChanged_AND_TextChanged(object sender, 
    		System.EventArgs e)
    {
    
       ComboBox comboBox = (ComboBox) sender;
    
       // in your case, this will execute on TextChanged but 
       // it will actually handle the selected index change
       if(_oldIndex != comboBox.SelectedIndex) 
       {
          // do what you need to do here ...   
          
          // set the current index to this index 
          // so this code doesn't exeute again
          oldIndex = comboBox.SelectedIndex;
       }
       // this will execute on SelecteIndexChanged but
       // it will actually handle the TextChanged event
       else if(_oldText != comboBox.Test) 
       {
          // do what you need to ...
          
          // set the current text to old text
          // so this code doesn't exeute again 
          _oldText = comboBox.Text;      
       }
    
    }
