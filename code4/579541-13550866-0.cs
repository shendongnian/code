    if(ViewState["Sets"] != null)
    {
        int sets = (int)ViewState["Sets"];
        for (int i = 0; i < sets; i++)
        {
            Set set = new Set();
            set.ID =  string.Format("set{0}", i);
            WeightList.Controls.Add(set);
         }
     }
