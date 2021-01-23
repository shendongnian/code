    using Microsoft.VisualBasic.Devices;
    ...
    private static readonly Keyboard KEYBOARD = new Keyboard();
    private static Keys GetPressedModifiers()
    {
        var mods = Keys.None;
        if (KEYBOARD.AltKeyDown)
        {
            mods |= Keys.Alt;
        }
        if (KEYBOARD.CtrlKeyDown)
        {
            mods |= Keys.Control;
        }
        if (KEYBOARD.ShiftKeyDown)
        {
            mods |= Keys.Shift;
        }
        return mods;
    }
