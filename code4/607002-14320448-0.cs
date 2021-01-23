        if (currentText != newtext)
        {
            // This solves the problem of initial text being tagged as changed text
            if (currentText == "")
            {
                IsDirty = false;
            }
            else
            {
                //OnIsDirtyChanged();
                IsDirty = true; //might have to change with the dirty marker
            }
            currentText = newtext;
        }
