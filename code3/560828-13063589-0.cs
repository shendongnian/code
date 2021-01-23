    for(i = 0; i < 4; i++)
    {
        m_registerBase[i] = new RadioButton();        
        m_registerBase[i].IsChecked=true;
        //Sets the Binding programmatcially
        m_registerBase[i].SetBinding(RadioButton.Content, "MyContent");
    }
