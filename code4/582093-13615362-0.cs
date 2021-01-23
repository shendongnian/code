    public static int CompareWithBoxingAndVirtualMethodCall(bool value)
    {
        if (value.Equals(false)) { return 0; } else { return 1; }
    }
    public static int CompareWithCILInstruction(bool value)
    {
        if (value == false) { return 0; } else { return 1; }
        if (!value) { return 0; } else { return 1; } // comparison same as line above
    }
