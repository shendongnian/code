    string[] words = result.Split(' ');
    Double newresult;
    foreach(string i in words)
    {
    if(Double.TryParse(i) == true)
    {
    if(!Double.Parse(i).equals(inputValue))
    {
    newresult = Double.Parse(i);
    break;
    }
    }
