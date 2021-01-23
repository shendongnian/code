    string str = "ABCDEFGHI";
    List<string> lst = new List<string>();
    string temp = "";
    for(int i = 0; i < str.Length; i++)
    {
        temp = str[i].ToString();
        if((i + 1) % 3 == 0)
        {
            lst.Add(temp);
            temp = "";
        }
    }
    string final_str = string.Join(", ", lst);
