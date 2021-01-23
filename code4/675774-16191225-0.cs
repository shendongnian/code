        private static bool IsDateGerman(string germanDate)
        {
            Regex rx = new Regex(@"[0-3]?[0-9]\.[0-1]?[1-9]\.[0-9]{1,4}");
            return rx.IsMatch(germanDate);
        }
