            string temp = "Business Invitation, start time, M Problem, 518-06-xxx, 9999 999 0783, Meeting ID, xxx ??";
            string newID = "1234";
            string[] firstSplits = Regex.Split(temp, "0783,");
            string[] secondSplits = Regex.Split(firstSplits[1], ",");
            secondSplits[0] = newID;
            string @join = string.Join(",", secondSplits);
            firstSplits[1] = @join;
            string newString = string.Join("0783,", firstSplits);
