            var str = "91212";
            if (str.Length == 5)
            {
                str = "0" + str;
            }
            var dtDate = DateTime.ParseExact(str, "HHmmss", System.Globalization.CultureInfo.CurrentCulture);
            System.Diagnostics.Debug.WriteLine(dtDate.ToShortTimeString());
