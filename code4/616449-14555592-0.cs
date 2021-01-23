            int maxPointGiven = scoreManager.numPlayers;
            int previousScore = 0;
            int previousPosition = 0;
            int previousPoints = 0;
            int countGiven = 0;
            bool newCount = true;
            for (int i = (scoreList.Count - 1); i >= 0; i--)
            {
                if (newCount == true)
                {
                    previousPosition = i + 1;
                    previousScore = scoreList[i].Value;
                    previousPoints = maxPointGiven;
                    newCount = false;
                }
                if (scoreList[i].Value == previousScore)
                {
                    int oldPoints = int.Parse(dgvPlayers.Rows[scoreList[i].Key].Cells[2].Value.ToString());
                    dgvPlayers.Rows[scoreList[i].Key].Cells[2].Value = previousPoints + oldPoints;
                    countGiven += 1;
                }
                else
                {
                    int oldPoints = int.Parse(dgvPlayers.Rows[scoreList[i].Key].Cells[2].Value.ToString());
                    previousPosition = i + 1;
                    previousScore = scoreList[i].Value;
                    previousPoints = maxPointGiven - countGiven;
                    dgvPlayers.Rows[scoreList[i].Key].Cells[2].Value = previousPoints + oldPoints;
                    countGiven += 1;
                }
            }
