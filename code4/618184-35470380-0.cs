    protected void CustomValidator_Date(object source, ServerValidateEventArgs args)
        {
            IFormatProvider culture = new CultureInfo("en-AU", true);
            try
            {
                String[] formats = { "dd MM yyyy", "dd/MM/yyyy", "dd-MM-yyyy" };
                DateTime dt1;
                dt1 = DateTime.ParseExact(args.Value, formats, culture, DateTimeStyles.AdjustToUniversal);
                args.IsValid = true;
            }
            catch
            {
                args.IsValid = false;
            }
        }
