    private static int scoreArray(int[] theArray, int goodValue, int badValue)
        {
            for (int i = 0; i < theArray.Length; i++)
            {
                if ((theArray[i] % goodValue == 0) & (theArray[i] % badValue == 0))
                {
                    score += 2;
                }
                else if (theArray[i] % goodValue == 0)
                {
                    score += 1;
                }
                else if ((theArray[i] % badValue == 0))
                {
                    score -= 1;
                }
                //score += score; //You dont need this.
            }
            return score;
        }
