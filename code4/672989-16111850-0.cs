    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern int GetDoubleClickTime(); 
    //GetDoubleClickTime returns the maximum milliseconds two clicks must be made in
    //to count as a double click
    Debug.WriteLine(GetDoubleClickTime());
