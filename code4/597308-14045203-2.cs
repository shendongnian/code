    public bool checkFileCreationDate(FileInfo fileInfo)
    {
        double num = (double)nudDays.Value;
        if (DateTime.Now.Subtract(fileInfo.CreationTime).TotalDays <= num)
        {
            return true;
        }
    
        return false;
    }
