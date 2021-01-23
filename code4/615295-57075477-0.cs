    void MsgPopup(string text, string title, int secs = 3)
    {
        dynamic intr = Microsoft.VisualBasic.Interaction.CreateObject("WScript.Shell");
        intr.Popup(text, secs, title);
    }
    
    bool MsgPopupYesNo(string text, string title, int secs = 3)
    {
        dynamic intr = Microsoft.VisualBasic.Interaction.CreateObject("WScript.Shell");
        int answer = intr.Popup(text, secs, title, (int)Microsoft.VisualBasic.Constants.vbYesNo + (int)Microsoft.VisualBasic.Constants.vbQuestion);
        return (answer == 6);
    }
