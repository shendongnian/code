            for (int index = 0; index < tempList.Count; index++)
            {
                sum += tempList[index];
                if (sum > result)
                {
                    result = sum;
                    startIndex = tempStart;
                    endIndex = index;
                }
                if (sum < 0)
                {
                    sum = 0;
                    tempStart = index + 1;
                }
            }
