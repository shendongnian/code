    int[] curValues=new int[]{5,10,20,50,100,200,500};
    foreach(int x in curValues)
    {
    output+=","+"EUR"+x+"-"+parseDenomination(x,input);
    }
    //output has your desired output
--------
    private static int parseDenomination(int no,String input)
    {
            return Regex.Matches(@"(?<=EUR"+no+@"-)\d+",input)
                        .Cast<Match>()
                        .Select(x=>int.Parse(x))
                        .ToList()
                        .Sum();
    }
