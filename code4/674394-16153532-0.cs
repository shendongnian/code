        else
        {
            dt = new DataTable("Gjester");
            dt.Rows.Add(gjestenavnInput.Text, datoInnsjekk.Text, antallDager.Text);
            ds.Merge(dt);
            ds.WriteXml("gjesteInfo.xml");
        }
