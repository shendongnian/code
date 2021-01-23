    @model Nullable<DateTime>
    @{
        DateTime dt = DateTime.Now;
        if (Model != null) {
            dt = (System.DateTime)Model;
        }
        @dt.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    }
