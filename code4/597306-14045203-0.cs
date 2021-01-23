    public bool checkFileCreationDate(FileInfo fileInfo)
    {
        double num = (double)nudDays.Value * -1;
        if (DateTime.Now.Subtract(fileInfo.CreationTime).TotalDays <= num)
        {
            return true;
        }
    
        return false;
    }
