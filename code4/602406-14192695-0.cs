    // Declare this at class level
    private Dictionary<CheckBox, Label> myControls = new Dictionary<CheckBox, Label>();
    // ...
    // Dictionary initialization goes in the ctor 
    // unless you generate the controls at run-time. 
    // If you generate controls, place it after the generation itself
    myControls.Add(chk1, lab1);
    myControls.Add(chk2, lab2);
    // and so on...
    // ...    
    // When you want to cycle, do this:
    foreach(var controlsPair in myControls) {
        // controlsPair is KeyValuePair<CheckBox, Label>
        if(controlsPair.Key.Checked) continue; // SEE (*) BELOW
        controlsPair.Value.Text = rng.Next(1, 7).ToString();
    }
