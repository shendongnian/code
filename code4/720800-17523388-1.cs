    [Flags]
    internal enum ShowTipAction
    {
        STA_Nothing = 1,
        STA_Clicked_Nothing = 2,
        STA_Clicked_OpenLink = 4,
        STA_Clicked_WriteReg = 8,
        STA_Closed_Nothing = 16,
        STA_Closed_WriteReg = 32,
        STA_Shown_Nothing = 64,
        STA_Shown_WriteReg = 128
    }
