    public void ShowOther(string input)
    {
        Console.Write(GetOther(input));
    }
    public char[] GetOther(String input)
    {
        char [] holder = input.ToCharArray();
        for (int i = 0; i < holder.Length; i++)
        {
            if (other.Contains(holder[i]))
            {
                holder.SetValue('^', i);
            }
            if (goodChars.Contains(holder[i]))
            {
                holder.SetValue(' ', i);
            }
        }
        return holder;
    }
