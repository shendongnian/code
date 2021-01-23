        internal static Farbe Get(Datenbank.Farbe data)
        {
            try
            {
                if (data == null)
                    return null;
                return DataPortal.FetchChild<Farbe>(data);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString()); 
            }
            return null;
        }
        private void Child_Fetch(Datenbank.Farbe data)
        {
            LoadProperty(FarbauswahlNrProperty, data.FarbauswahlNr);
            LoadProperty(KurztextProperty, data.Kurztext);
            LoadProperty(RessourceProperty, data.Ressource);
            LoadProperty(Vari1Property, data.Var1);
            LoadProperty(Vari2Property, data.Vari2);
        }
