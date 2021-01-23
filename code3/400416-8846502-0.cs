        static int cardGameValue(List<int> D, int myScore, int opponentScore)
        {
            if (D.Count == 0) return myScore;
            else if (D.Count == 1)
            {
                opponentScore += D[0];
                return myScore;
            }
            else
            {
                if (D[0] <= D[D.Count - 1])
                {
                    opponentScore += D[D.Count - 1];
                    D.RemoveAt(D.Count - 1);
                }
                else
                {
                    opponentScore += D[0];
                    D.RemoveAt(0);
                }
                int left = cardGameValue(new List<int>(D.GetRange(1, D.Count - 1)), myScore + D[0], opponentScore);
                int right = cardGameValue(new List<int>(D.GetRange(0, D.Count - 1)), myScore + D[D.Count - 1], opponentScore);
                if (left >= right)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }
