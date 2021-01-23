    List<string> SplitString(String input, int length)
    {
        var splitedList = new List<string>();
        string block = "";
        var arabicBlock = "";
        foreach (char c in input)
        {
            if (block.Length + arabicBlock.Length > length - 1)
            {
                splitedList.Add(block);
                block = "";
            }
            var b = (int) c;
            // check here if charachter is arabic
            // this is a sample
            if (b > 6000)
            {
                arabicBlock += c.ToString();
            }
            else
            {
                block += arabicBlock + c;
                arabicBlock = "";
            }
        }
        return splitedList;
    }
