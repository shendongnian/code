    private void SpanishCB_checkChanged(object sender, EventArgs e)
    {
    LanguageGroup LG = new LanguageGroup(); 
    for(int i =0; i<LG.Count(); i++)
    {
    if(LG.LanguageID.ID == LatinAmericaID)
    {
    int index = checkedListBox1.IndexOf(nL.LanguageID[i].Language);
    checkedListBox.SetItemsChecked(index, checked(CheckState.Checked));
    }
    }
    }
