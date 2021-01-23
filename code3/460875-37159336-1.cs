    private void SetHelpBoderColor(bool showBorder)
    {
        if (showBorder)
        {
            //Set Default ViewBackColor
            PropertyInfo viewBackColor = this.propertyGrid.GetType().GetProperty("ViewBorderColor");
            if (viewBackColor != null)
                viewBackColor.SetValue(this.propertyGrid, SystemColors.ControlDark, null);
            //Set Default HelpBorderColor
            PropertyInfo helpBorderColor = this.propertyGrid.GetType().GetProperty("HelpBorderColor");
            if (helpBorderColor != null)
                helpBorderColor.SetValue(this.propertyGrid, SystemColors.ControlDark, null);
        }
        else
        {
            //Set ViewBackColor
            PropertyInfo viewBackColor = this.propertyGrid.GetType().GetProperty("ViewBorderColor");
            if (viewBackColor != null)
                viewBackColor.SetValue(this.propertyGrid, SystemColors.Control, null);
            //Set HelpBorderColor
            PropertyInfo helpBorderColor = this.propertyGrid.GetType().GetProperty("HelpBorderColor");
            if (helpBorderColor != null)
                helpBorderColor.SetValue(this.propertyGrid, SystemColors.Control, null);
        }
        if (DesignMode)
        {
            Parent.Refresh();
        }
    }
