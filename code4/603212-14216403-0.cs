    DataTable arrySBitClone = arrySBit.Copy();
    arrySBit.DefaultViewSort.Sort = "Bit";
    
    bool different = false;
    for(int i=0; i<arrySBit.Rows.Count; i++)
    {
      if(arrySBit.Rows[i]["Bit"]!=arrySBitClone.Rows[i]["Bit"])
      {
        difference = true;
        break;
      }
    }
    
    if(!different)
    {
      arrySBit = arrySBit.Copy(); 
    }
