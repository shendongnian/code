    List<string> GetOrderOfOccurence(string text, List<string> keywords)
    {
        List<string> target = new List<string>(); //Initialize a new List of string array of name target
        #region Creating the pattern
        string Pattern = "("; //Initialize a new string of name Pattern as "("
        foreach (string x in keywords) //Get x as a string for every string in keywords
        {
            Pattern +=  x + "|"; //Append the string + "|" to Pattern
        }
        Pattern = Pattern.Remove(Pattern.LastIndexOf('|')); //Remove the last pipeline character from Pattern
        Pattern += ")"; //Append ")" to the Pattern
        #endregion
        Regex _Regex = new Regex(Pattern); //Initialize a new class of Regex as _Regex
        foreach (Match item in _Regex.Matches(text)) //Get item as a Match for every Match in _Regex.Matches(text)
        {
            target.Add(item.Value); //Add the value of the item to the list we are going to return
        }
        return target; //Return the list
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        List<string> keywords = new List<string>(){"Posterity", "Liberty", "Order", "Dinosaurs"}; //Initialize a new List<string> of name keywords which contains 4 items
        foreach (string x in GetOrderOfOccurence("We the People of the United States, in Order to form a more perfect Union, establish Justice, insure domestic Tranquility, provide for the common defence, promote the general Welfare, and secure the Blessings of Liberty to ourselves and our Posterity, do ordain and establish this Constitution for the United States of America.", keywords)) //Get x for every string in the List<string> returned by GetOrderOfOccurence(string text, List<string> keywords)
        {
            Debug.WriteLine(x); //Writes the string in the output Window
        }
    }
