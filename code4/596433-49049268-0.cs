    public static string ReversewordString(string Name)
        {
            string output="";
            char[] str = Name.ToCharArray();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    output = output + " ";
                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if (str[j] == ' ')
                        {
                            break;
                        }
                        output=output+ str[j];
                    }
                }
                if (i == 0)
                {
                    output = output +" ";
                    int k = 0;
                    do
                    {
                        output = output + str[k];
                        k++;
                    } while (str[k] != ' ');
                }
            }
            return output;
        }
