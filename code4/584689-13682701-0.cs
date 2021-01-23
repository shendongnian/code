    public List<object> GetNewMessages()
            {
                if (NewMessages.Count > 0 && InboxTemp.Count > 0)
                {
                    for (int j = 0; j < NewMessages.Count; j++)
                    {
                        bool found = false;
                        int i = 0;
                        while(!found && i<InboxTemp.Count)
                        {
                            if (InboxTemp[i].ID == NewMessages[j].ID)
                            {
                                found = true;
                            }
                            j++;
                        }
                        if(!found)
                            InboxTemp.Add(NewMessages[j]);
                    }
                }
                NewMessages.Clear();
                return InboxTemp;
            }
