            for (int i = 0; i < tcList.Count; i++)
            {
                if (tcList[i].TopBotData == 2 && tcList[i].ModulePosition == 1)
                {
                    result.Add(tcList[i]);
                }
            }
            return result;
