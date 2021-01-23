                    for (int j = 0; j < keywordSplit.Length; j++)
                    {
                        for (int k = 0; k < selectionSplit.Length; k++)
                        {
                            if (selectionSplit[k].ToLower().Contains(keywordSplit[j].ToLower()))
                            {
                                l++;
                                break;
                            }
                        }
                    }
