    private void ProcessTheMap_InBackground(WhateverTypeItIs_YouDidntSay mapname)
    {
        if (!bw.IsBusy)
        {
            bw.RunWorkerAsync(mapname);
        }
        else
        {//You are already loading something in the background
        }
    }
