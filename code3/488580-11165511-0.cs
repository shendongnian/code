    string[] m = new string[] { "Guest", "Admin", "Operator", "Unit Manager", "User" }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="m">the string array which searches for the integer criteria.</param>
    /// <param name="s"> the int32 number which will pass to the index of the array </param>
    /// <returns></returns>
    public static string IntToString( this string S, string[] m, int s)
    {
        string z = m.ElementAt(s);
        //Array.Clear(m, 0, m.Length);
        
        /// if you will need to clear the string array elements each using of this method then delete the comment slashes in front of the Array.Clear() method
       /// in Array.Clear method also -to depends of your need- you can disable to show the
       /// Array elements.. May be you will need only 1 admin and if an admin chooosen you can delete this option by changing the parameters of Array.Clear() Method
        
        return z;
    } 
