    private void lookUpEditPatients_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            var edit = sender as LookUpEdit;
            var props = edit.Properties;
            var pat = (Patients4ComboBoxVm) props?.GetDataSourceRowByKeyValue(e.Value);
            if (pat != null)
            {
                e.DisplayText = pat.Nachname + ", " + pat.Vorname + "; " + pat.Geburtsdatum + "; " + pat.Versicherungsnummer;
            }
        }
