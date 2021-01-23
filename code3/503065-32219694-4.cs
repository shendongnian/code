    Colour col; 
            col = Colour.Red;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            var ListOfColors = typeof(Colour).GetEnumValues().Cast<Colour>().Select(p => new { Id = p, Decr = GetStringDescription(p) }).ToList();
            foreach (var listentry in ListOfColors)
                Debug.WriteLine(listentry.Id + " " + listentry.Decr);
