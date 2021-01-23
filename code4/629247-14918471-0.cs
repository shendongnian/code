KeyDown += (o, ea) =>
{
    System.Diagnostics.Debug.WriteLine("KeyDown => CODE: " + ea.KeyCode +
        ", DATA: " + ea.KeyData +
        ", VALUE: " + ea.KeyValue +
        ", MODIFIERS: " + ea.Modifiers +
        ", CONTROL: " + ea.Control +
        ", ALT: " + ea.Alt +
        ", SHIFT: " + ea.Shift);
                    
};
KeyUp += (o, ea) =>
{
    System.Diagnostics.Debug.WriteLine("KeyUp => CODE: " + ea.KeyCode +
        ", DATA: " + ea.KeyData +
        ", VALUE: " + ea.KeyValue +
        ", MODIFIERS: " + ea.Modifiers +
        ", CONTROL: " + ea.Control +
        ", ALT: " + ea.Alt +
        ", SHIFT: " + ea.Shift);
};
KeyPress += (o, ea) => 
{
    System.Diagnostics.Debug.WriteLine("KeyPress => CHAR: " + ea.KeyChar);
};
