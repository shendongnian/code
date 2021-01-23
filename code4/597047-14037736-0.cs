    //call
    MessageBox.Show(GetNewDateString(new DateTime(2012, 11, 30)) + "\n" + GetNewDateString(new DateTime(2012, 12, 1)));
    public String GetNewDateString(DateTime dt)
    {
       return dt.Day > 9 ? String.Format("{0:MMM d yyyy}", dt) : String.Format("{0:MMM   d yyyy}", dt);
    }
