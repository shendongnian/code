    public bool controllaSelezioneSottopagina(KPage k_oPaginaAttuale, KPage k_oPaginaSuperiore)
    {
        foreach (KPage k_oSottoPagina in k_oPaginaSuperiore.SottoPagine)
        {
            if (k_oSottoPagina.ID == k_oPaginaAttuale.ID)
            {
                return true;
            }
            else
            {
                if (k_oSottoPagina.SottoPagine.Count != 0)
                {
                    if(controllaSelezioneSottopagina(k_oPaginaAttuale, k_oSottoPagina))
                    {
                      return true;
                     }
                }
            }
        }
    
        return false;
    }
