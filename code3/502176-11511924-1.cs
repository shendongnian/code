    string[] xFrames = new string[wocl.Count];
    string[] yFrames = new string[wocl.Count];
    for (int i = 0; i < wocl.Count; i++)
    {
       xFrames[i] = string.Format("Frame_X_{0} ", i + 1);
       yFrames[i] = string.Format("Frame_Y_{0} ", i + 1);
       for(int j =0; j < wocl[i].Length; j++)
       {
           xFrames[i] += string.Format("{0},", wocl[i].Point_X[j]);
           yFrames[i] += string.Format("{0},", wocl[i].Point_Y[j]);
       }
       xFrames[i].Trim(",".ToCharArray());
       yFrames[i].Trim(",".ToCharArray());
    }
