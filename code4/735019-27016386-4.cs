    public event EventHandler<TextChangeEventArgs> UpdateTextBox;
    private string strText; 
    public string prpStrText
    {
         get { return strText; }           
         set
         {
              if (strText != value)
              {
                   strText = value;
                   OnTextBoxTextChanged(new TextChangeEventArgs(strText));
              }
         }
    }
    
    private void textBox_Form2_TextChanged(object sender, EventArgs e)
    {
         prpStrText = txtBox_Form2.Text;
    }
    
    protected virtual void OnTextBoxTextChanged(TextChangeEventArgs e)
    {            
         EventHandler<TextChangeEventArgs> eventHandler = UpdateTextBox;
         if (eventHandler != null)
         {
               eventHandler(this, e);
         }
    }
