    StreamReader sr = new StreamReader("inputs.txt");
    string line = null;
    line = sr.ReadToEnd();
    var str = line.Trim().Split('\n');
    int length = str.Length;
    int[] arr=new int[sr.Length,2];
    int index=0;
    
    while (index < length)
    {
        var pair = str[index].Split(',');
        var item1 = pair[0];
        var item2 = pair[1];
        arr[index]=new int[]{item1,item2};
    
        index++;
    }
    
    for (int i=0;i<arr.Length;i++)
    {
        for (int j=i+1;j<arr.Length;j++)
        {
             if  (arr[i][1] == arr[j][0])
             {
                     //MATCH
             }
             else
             {
                     //FAILURE
              }
        }
    }
