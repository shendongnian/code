    public void goDownLinkType2(string[] splittedString, int index, SuffixNode currentNode)
    {
        Boolean writingFlag = false;
        if (index == 2)
        {
            while(writingFlag == false)
            {
                lock( this )
                //while(flag == true)
                //{
                    //blocked
                //}
                //if (flag == false)
                {
                    //flag = true;
                    if (!secondChoiceResults.Contains(currentNode.representingStance.SequenceOfHolds))
                    {
                        Console.WriteLine("new addition");
                        secondChoiceResults.Add(currentNode.representingStance.SequenceOfHolds, currentNode.representingStance);
                    }
                    //flag = false;
                    writingFlag = true;
                }
            }
        }
        else
        {
            int nextIndex = index + 1;
            goDownLinkType2(splittedString, nextIndex, (SuffixNode)currentNode.childHolds[splittedString[nextIndex]]);
        }
    }
