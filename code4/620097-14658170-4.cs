    void AddEvents(System.Windows.Forms.Control.ControlCollection Controls)
    {
        foreach (Control c in Controls)
        {
            if (c is GroupBox)
            {
                AddEvents(((GroupBox)c).Controls);
            }
            else if (c is Panel)
            {
                AddEvents(((Panel)c).Controls);
            }
            //Expand this series of if...else... to include any 
            //other type of container control
            else if (c is TextBox)
            {
                ((TextBox)c).TextChanged += new EventHandler(MyHandler);
            }
            else if (c is RichTextBox)
            {
                ((RichTextBox)c).TextChanged += new EventHandler(MyHandler);
            }
            else if (c is CheckBox)
            {
                ((CheckBox)c).CheckedChanged += new EventHandler(MyHandler);
            }
            else if (c is DateTimePicker)
            {
                ((DateTimePicker)c).ValueChanged += new EventHandler(MyHandler);
            }
            //Expand this to include any other type of controls your form 
            //has that you need to add the event to
        }
    }
