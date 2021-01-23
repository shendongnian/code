    foreach (string sc in serverCabinetNames)
                {
                    bool cabinetExists = false;
                    foreach (string cv in CabinetValues)
                    {
                        if (sc == cv)
                        {
                            cabinetExists = true;
                            break;
                        }
                    }
    foreach (string s in cabinetsCurrentNotUsed)
    {
        if(s != null)
              lbxCabinetName.Items.Add(s);
    }
                }
