    // Not needed: see below.  List<string> list1 = new List<string>();
    using (StreamReader reader = new StreamReader(FileLocation))
    {
        string line1;
        //max 500
        List<string> LineArray1 = new List<string>();
        while ((line1 = reader.ReadLine()) != null)
        {
            // list1.Add(line1); // Add to list.
            // By adding to the list, then searching it, you are searching the whole list for every single new line - you're searching through the same elements multiple times.
            if (string.Compare(line1, cust1[AddressLength1].ToString(), true) == 0)
            {
                // You can just use LineArray1.Count for this instead. count1++;
                LineArray1.Add(line1);
            }
        }
        // Not needed: using() takes care of this.  reader.Close();
        using (System.IO.StreamWriter filed =
            new System.IO.StreamWriter(FileLocation, true))
        {
            filed.WriteLine(); // You don't need an empty string for a newline.
            filed.WriteLine("The email address " +
            cust1[AddressLength1].ToString() + " was found " + LineArray1.Count +
            " times within the recipient's inbox");
        }
        string count1a;
        count1a = LineArray1.Count.ToString();
    }
