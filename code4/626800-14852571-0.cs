    `          for (int i = 0; i < skype.MissedMessages.Count; i++)
                {
                    if (skype.MissedMessages[i + 1].Type == TChatMessageType.cmeSaid)
                    {
                        string unreadMessage = skype.MissedMessages[i + 1].Body;
                    }
                 }`
