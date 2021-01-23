    public void File_Changed( object source, FileSystemEventArgs e )
    {
        string filePath = @"C:\MACHINE_1.txt";
        if(!File.Exist(filePath))
            return;
        string MACH1 = File.ReadText(filePath).Last();
        if (MACH1=="SETUP")
        {
            MACHINE1IND.BackColor = Color.Green; 
        }
        else
        {
            MACHINE1IND.BackColor = Color.Red; 
        }
    }
