      private DateTime? datumOd = null;
      private DateTime datOd;
      datOd = datumOd.HasValue ? datumOd.Value : DateTime.Now.AddYears(-20);
      if (datumOd.HasValue)
            {
                parameters[0] = new ReportParameter("DatumOd", datOd.ToString("dd.MM.yyyy 
                HH:mm"));
            }
            else
            {
                parameters[0] = new ReportParameter("DatumOd");
            }
