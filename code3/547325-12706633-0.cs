            for (int i = 0; i < mathes.Count; i++)
            {
                if (mathes[i].Index > index) return mathes[i-1].Index;
            }
            
            return -1;
        }
        int IndexOf(MatchCollection mathes, int index)
        {
            for (int i = 0; i < mathes.Count; i++)
            {
                if (mathes[i].Index > index) return mathes[i].Index;
            }
            return -1;
        }
