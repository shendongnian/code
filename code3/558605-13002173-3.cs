    public void SwitchControls(Control removeCtrl, Control addControl)
    {
         panel1.Controls.Remove(removeCtrl);
         panel1.Controls.Add(addControl);
    }
