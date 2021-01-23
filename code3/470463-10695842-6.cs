    private void selectCabinetToAdd()
    {
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
                    if (!cabinetExists)
                    {
                        cabinetsCurrentNotUsed.Add(sc);
                    }
                }
            }
            foreach (string ccnu in cabinetsCurrentNotUsed)
            {
                if (ccnu != null)
                    lbxCabinetName.Items.Add(ccnu);
            }
       }
