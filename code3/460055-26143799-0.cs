    /// <summary>
    /// This additional code block checks the locations of links
    /// and desc. it via a string which contains informations of how many links are there
    /// .Split('&')-1 and the select information .Select(.Split('&')[i].Split('-')[0],.Split('&')[i].Split('-')[1])
    /// After we select the links we can SetSelectionLink(true) to get our links back.
    /// </summary>
    public string getLinkPositions()
    {
    string pos = "";
    for (int i = 0; i < this.TextLength; i++)
    {
    this.Select(i, 1);
    int isLink = GetSelectionLink();
    if (isLink == 1)
    {
    //the selected first character is a part of link, now find its last character
    for (int j = i + 1; j <= this.TextLength; j++)
    {
    this.Select(j, 1);
    isLink = GetSelectionLink();
    if (isLink != 1 || j == this.TextLength)
    {
    //we found the last character's +1 so end char is (j-1), start char is (i)
    pos += (i) + "-" + ((j - 1) - (i - 1)) + "&"; //j-1 to i but i inserted -1 one more so we can determine the right pos
    i = j; //cont. from j+1
    break; //exit second for cont. from i = j+1 (i will increase on new i value)
    }
    }
    }
    }
    this.DeselectAll();
    return pos;
    }
    /// <summary>
    /// This method generates the links back only created via InsertLink(string text)
    /// and overloaded InsertLink(string text,int position)
    /// </summary>
    /// <param name="pos">the pos string from getLinkPositions</param>
    public void setLinkPositions(string pos)
    {
    string[] positions = pos.Split('&');
    for (int i = 0; i < positions.Length - 1; i++)
    {
    string[] xy = positions[i].Split('-');
    this.Select(Int32.Parse(xy[0]), Int32.Parse(xy[1]));
    this.SetSelectionLink(true);
    this.Select(Int32.Parse(xy[0]) + Int32.Parse(xy[1]), 0);
    }
    this.DeselectAll();
    }
