    private static void SetCustomIcon(Outlook.MAPIFolder folder)
    {
        Icon icon = null;
        try
        {
            icon = Properties.Resources.myCustomIcon_16x16;
            stdole.StdPicture iconPictureDisp = PictureDispConverter.ToIPictureDisp(icon) as stdole.StdPicture;
            folder.SetCustomIcon(iconPictureDisp);
        }
        finally
        {
            icon.Dispose();
        }
    }
