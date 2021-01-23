    public static List<BoxPair> CreateBoxPair (int iBoxCount)
    {
        SetTopBox primary;
        SetTopBox backup;
        List<BoxPair> lstBoxes = new List<BoxPair>();
    
        for (int i = 0; i < iBoxCount; i++)
        {
            primary = new SetTopBox();
            backup = new SetTopBox();
    
            primary.IBoxNumber = i;             
            primary.SDeviceName = "Box" + (i + 1).ToString("00");
            primary.Role = Box.ROLE_PRIMARY;
    
            backup.IBoxNumber = i;
            backup.SDeviceName = "Box" + (i + 1).ToString("00");
            backup.Role = Role.ROLE_BACKUP;
    
            lstBoxes.Add(new BoxPair(primary, Role));
            lstBoxes.Add(new BoxPair(backup, Role));
    
            foreach (BoxPair p in lstBoxes)
            {
                Declarations.BOXES.Add(p);
            }             
        }                        
    
        return lstBoxes;
    }
