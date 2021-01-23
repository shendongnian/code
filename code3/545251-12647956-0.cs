    Keys specials = keyData & Keys.Modifiers;
    Keys keycode = keyData & ~Keys.Modifiers;
    bool withShift = specials.HasFlag( Keys.Shift );
    bool withControl = specials.HasFlag( Keys.Control );
    bool withAlt = specials.HasFlag( Keys.Alt );
    if(keycode == Keys.F1 && !withShift && !withControl && !withAlt)
        ; // it was plain F1 with no specials
    else if(keycode == Keys.VolumeUp)
        ; // it was 'volume-up' key with any or none of the modifiers
    else if(keycode >= Keys.A && keycode <= Keys.Z && withControl)
        ; // it was CTRL+Letter
    else if(keycode >= Keys.D0 && keycode <= Keys.D9 && withShift)
        ; // it was SHIFT+Digit
