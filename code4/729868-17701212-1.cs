    if (isModified & !Report)
    {
       mReactantNumericUpDown.Value = mNumericUpDownValue;   
    }
    else
    {
       mReactantGroup = (int)mReactantNumericUpDown.Value;
       ClearUserValues();
       UpdateControls();
    }
