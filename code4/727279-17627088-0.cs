        List<Control> cleanControls = new List<Control>();
        foreach(Control ctr in Controls)
        {
           if(cntrl.GetType() != typeof(Button))
           {
              cleanControls.Add(ctr);
           }
           else
           {
             ctr.Dispose();
           }
        } 
        Controls = cleanControls;
