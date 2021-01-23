    private int? returnIndex(int val = 15)
            {
                List<int> myList = new List<int>() { 12, 34, 4, 65 };
                int listCount = myList.Count;
                int? position = null;
                for (int i = 0; i < listCount; i++)
                {
                    var currPosition = myList[i];
                    if (i + 1 >= listCount)
                    {
                        position = i;
                        break;
                    }
                    var nextPosition = myList[i + 1];
                    if (val >= currPosition && val <= nextPosition)
                    {
                       position = nextPosition;
                       break;
                     }
                    continue;
                }
                return position;
            }
