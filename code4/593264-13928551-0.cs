    string line = "while(i<10){CommandID = 15852; i+=1;}";
    //I've put a complicated code in the string to make you sure
    var rightSideOfAssignment = line.Split(new string[] {"CommandID"}, StringSplitOptions.RemoveEmptyEntries)[1];
    int val = 0,temp;
    bool hasAlreadyStartedFetchingNumbers= false;
    foreach (char ch in rightSideOfAssignment)  //iterate each charachter
    {
        if (int.TryParse(ch.ToString(), out temp)) //if ch is a number
        {
            foundFirstInteger = true;
            val *= 10;
            val += temp;
        }
        else
        {
            if (hasAlreadyStartedFetchingNumbers)
                break;
            //If you don't check this condition, it'll result to 158521
            //because after hitting `;` it won't stop searching
        }
    }
    MessageBox.Show(val.ToString()); //shows 15852
