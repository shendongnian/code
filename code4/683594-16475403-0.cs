    foreach (var item in rows)
    {
        var skillData = (BsonArray)item["skillData"];//this is the array of the document
    
        Console.WriteLine(skillData);
        int i=0;
        while(i < 5)
        {
            for (int j = 0; j < skillData.Count; j++)
            {
                var skillIDs = skillData[j].AsBsonDocument.GetValue("skillID").ToString();
                if (skillIDs == equipTileArray[i])
                {
                    isSkillIDFound = true;
                    break;
                }
            }
            i++;
        }
    }
