    public static void CheckNextInGroup(this RadioButton radioButton, bool forward) {
        var parent = radioButton.Parent;
        var radioButtons = parent.Controls.OfType<RadioButton>();  //get all RadioButtons in the relevant container
        var ordered = radioButtons.OrderBy(i => i.TabIndex).ThenBy(i => parent.Controls.GetChildIndex(i)).ToList();  //Sort them like Windows does
        var indexChecked = ordered.IndexOf(radioButtons.Single(i => i.Checked)); //Find the index of the one currently checked
        var indexDesired = (indexChecked + (forward ? 1 : -1)) % ordered.Count;  //This allows you to step forward and loop back to the first RadioButton
        if (indexDesired < 0) indexDesired += ordered.Count;  //Allows you to step backwards to loop to the last RadioButton
        ordered[indexDesired].Checked = true;
    }
