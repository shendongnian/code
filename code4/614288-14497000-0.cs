    public ArrayList Location(int p_1, int p_2, int p_3, int p_4)
    {
     ArrayList ar = new ArrayList();
     ar.AddRange(new string[] { "", "" });  
     int  XLocation = p_2 - p_1;
     int YLocation = p_4-p_3;
     ar[0] = XLocation.ToString(); 
     ar[1] = YLocation.ToString(); 
     return ar;
     }
