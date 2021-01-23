    public bool IsSchoolYearFormat(string toCheck)
    {
        string[] arr = toCheck.Trim().Split('-'); //splits the string, eg 2013-2014 goes to 2013 and 2014
        if (arr.Length != 2) //if there is less or more than two school years it is invalid.
        {
            return false;
        }
        int one, two;
        if (!int.TryParse(arr[0], out one))
        {
            return false;
        }
        if (!int.TryParse(arr[1], out two))
        {
            return false;
        }
        //if they don't parse then they are invalid.
        return two - 1 == one;
        //school year must be in the format yeara-(yeara+1)
    }
