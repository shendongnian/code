    [...]
    else if (curBaseline[Vector.I2] < lastBaseLine[Vector.I2])
    {
        if (curAscentLine[Vector.I2] < lastDescentLine[Vector.I2])
        {
            firstcharacter_baseline = character_baseline;
            this.result.Append("<br/>");
        }
        else
        {
            difference = firstcharacter_baseline - curBaseline[Vector.I2];
            text_second.SetTextRise(difference);
            if (difference == 0)
            {
            }
            else
            {
                SupSubFlag = 2;
            }
        }
    }
    [...]
