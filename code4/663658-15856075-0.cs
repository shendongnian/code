    string a = "ABCD";
    string b = "WXYZ";
    string c = string.Empty;
    if(a.Lenght == b.Lenght)//Check lenght
    {
       for(int i = 0; i < a.Lenght; i++)
       {
          c += a[i] + "-" + b[i];
          if(i != a.Lenght)//If it isn't last character
          {
             c += "-";//Add a "-" end of "c"
          }
       }
    }
