    StringBuilder strBuilder = new StringBuilder();
    int startPos = 0;
    for (int i = 0; i < text.Length / 4; i++)
    {
        startPos = i * 4;
        strBuilder.Append(text.Substring(startPos,4));
                                                
        //if it isn't the end of the string add a hyphen
        if(text.Length-startPos!=4)
            strBuilder.Append("-");
    }
    //add what is left
    strBuilder.Append(text.Substring(startPos, 4));
    string textWithHyphens = strBuilder.ToString();
