    UserControl _step1Control = new UcStep1Control;
    UserControl _step2Control = new UcStep2Control;
    private void SetStep(int stepNumber)
    {
        panel1.Controls.Clear();
        switch(stepNumber)
        {
            case 1:
                panel.Controls.Add(_step1Control);
                break;
            case 2:
                panel1.Controls.Add(_step2Control);
                break;
            default:
                break;
          }
    }
    
    
