    uc.TryGetValue<List<sMedication>>("medicationList", out medicationList)
    if (medicationList != null)
    {
       foreach(sMedication temp in medicationList)
       {
           lastID = temp.UniqueID;
           return lastID;
       }
    }
    else
    {
       // handle the key not being there
    }
