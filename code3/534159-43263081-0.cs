    //This Instances a new RichTextBox Control and uses it so save the Text
    private void Save_RTF_file(string pFilePath, string pRTFText)
    {
        try
        {
            using (RichTextBox RTB = new RichTextBox())
            {
                RTB.Rtf = pRTFText;
                RTB.SaveFile(pFilePath, RichTextBoxStreamType.RichText);
            } 
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
