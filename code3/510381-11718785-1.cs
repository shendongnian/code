    try
    {
        motelManager.SaveToFile(file);
    }
    catch (Exception e)
    {
        MessageBox.Show("Ett fel uppstod!", "Varning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
