    private void WyemitujFakture(List<int> lista)
    {
    foreach (int knh_id in lista)
    {
     try
    {
    if (luk.Count > 0)
    {
        FakturySprzedazy fs = new FakturySprzedazy();
        fs.FKS_AKCYZA = false;
        fs.FKS_CZY_KLON = false;
        fs.FKS_DATA_DOW_KS = Convert.ToDateTime(MTBDataZapisuDoFK.Text);
        fs.FKS_DATA_FAKTURY = Convert.ToDateTime(MTBDataFaktury.Text);
        fs.FKS_DATA_SPRZEDAZY = Convert.ToDateTime(MTBDataSprzedazy.Text);
        SessionScope session2 = new SessionScope(FlushAction.Never);
                        fs.Save();
                        session2.Flush();
       session2.Flush();
       if (session2 != null) session2.Dispose();
       Session.Flush();
        liczbaWygenerowach++;
    }
    }
    catch (Exception ex)
    {
    MessageBox.Show("Nie mozna wyemitowac faktury dla kontrahenta o id = " + knh_id.ToString() + " " + ex.Message);
    }
    ilosc_zrobionych++;
    fpb.PBStan.Value = (int)((100 * ilosc_zrobionych) / liczbaKontrahentow);
    Application.DoEvents();
    }
    }
