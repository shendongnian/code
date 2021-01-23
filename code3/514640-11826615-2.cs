    public static List<BoxPair> CreateBoxPair (int iBoxCount)
    {
        for (int i = 0; i < iBoxCount; i++)
        {
            var primary = new SetTopBox();
            var backup = new SetTopBox();
            primary.IBoxNumber = i;             
            primary.SDeviceName = "Box" + (i + 1).ToString("00");
            primary.Role = Box.ROLE_PRIMARY;
            
            backup.IBoxNumber = i;
            backup.SDeviceName = "Box" + (i + 1).ToString("00");
            backup.Role = Role.ROLE_BACKUP;
            var primaryPair = new BoxPair(primary, Role);
            var backupPair = new BoxPair(backup, Role);
            lstBoxes.Add(primaryPair);
            lstBoxes.Add(backupPair);
            Declarations.BOXES.Add(primaryPair);
            Declarations.BOXES.Add(backupPair);
        }                        
        return lstBoxes;
    }
