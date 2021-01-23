        for (int x = 0; x < splt.Length; x++)
        {
            int menuIndex;
            if(Int32.TryParse(splt[x], out menuIndex))
            {
                if(menuIndex >= 0 && menuIndex < mstrip.Length)
                    mstrip[menuIndex].Visible = true;
           }
        }
