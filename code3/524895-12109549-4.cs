    gbCtrl = new GroupBox();
    gbCtrl.Left   = 20; // <- These are relative to the main form.
    gbCtrl.Top    = 20;
    gbCtrl.Width  = 120;
    gbCtrl.Height = 60;
    gbCtrl.Text = "Sample GroupBox";
    
    Button btnSample = new Button();
    btnSample .Left = 22; // <- These are relative to the groupbox
    btnSample .Top  = 24; // 
    gbCtrl.Controls.Add(btnSample); // <- Add the button to the groupbox
    
    Controls.Add(gbCtrl); // <- Add the groupbox to the main form.
