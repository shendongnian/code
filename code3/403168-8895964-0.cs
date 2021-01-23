    public ArrayList FindLongest(params ArrayList[] lists)
    {
       var longest = lists[0];
       for(var i=1;i<lists.Length;i++)
       {
           if(lists[i].Length > longest.Length)
              longest = lists[i];
       }
       return longest;
    }
