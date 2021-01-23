    class myProject 
    {
       public static int length = 0; //Initialize a new int of name length as 0
       public static string[] myArray1 = new string[length]; //Initialize a new array of type string of name myArray1 as a new string array of length 0
       public static string[] myArray2 = new string[length]; //Initialize a new array of type string of name myArray2 as a new string array of length 0
    
    public static void setLength()
    {
        length = 5; //Set length to 5
    }
    
    public static void process()
    {
        setLength(); //Set length to 5
        Array.Resize(ref myArray1, length); //Sets myArray1 length to 5
        //Debug.WriteLine(myArray1.Length.ToString()); //Writes 5
    }
