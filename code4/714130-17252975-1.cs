    protected void SaveButtonEvent(object sender, EventArgs e)
    {
    MiddletierManager mm = new MiddletierManager();
    Kupac objectClass = new Kupac();
    
        objectClass.SifraKupca = this.hdnID.Value;
        objectClass.Ime = this.txtIme.Text;
            
        objectClass.Prezime = this.txtPrezime.Text;
            
        objectClass.BrojTelefona = this.txtBrojTelefona.Text;
            
        objectClass.Adresa = this.txtAdresa.Text;
            
    mm.Save(objectClass);
    }
    
