        string headingItem="unknown Item";
        while (!streamReader.EndOfStream)
        {
             string currentLine = streamReader.ReadLine();
            if (!currentLine.Contains('#') && currentLine != "" && !currentLine.Contains("["))
            {     
                String[] s = currentLine.Split(' ');
                npcID = int.Parse(s[0]);
                itemName = (s[1]);
                itemID = int.Parse(s[2]);
                itemAmount = int.Parse(s[3]);
                itemRarity = int.Parse(s[4]);
                dataGridView1.Rows.Add(headingItem, itemName, itemID, itemAmount, itemRarity);
                dataGridView1.Refresh();
            }
            else
            {
                headingItem=currentLine;
            }
        }
