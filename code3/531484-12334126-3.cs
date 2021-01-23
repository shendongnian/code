    Windows.UI.Input.CrossSlideThresholds cst = new Windows.UI.Input.CrossSlideThresholds();
    cst.SelectionStart = 2;
    cst.SpeedBumpStart = 3;
    cst.SpeedBumpEnd = 4;
    cst.RearrangeStart = 5;
    gr.CrossSlideHorizontally = true;
    gr.CrossSlideThresholds = cst;
    gr.CrossSliding += gr_CrossSliding;
