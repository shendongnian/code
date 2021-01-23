    public static void ToUpperCase(params ISupportUpperCase[] controls)
    {
        foreach (var oControl in controls)
        {
            oControl.TextChanged += (sndr, evnt) =>
            {
                oControl.TransformValueToUpperCase();
            }
        }
    }
