    public static class FlightCodeValidationExtensions {
        public static bool IsValidFlightCode(this string str) {
            return Regex.IsMatch(flightCode, @"^[a-zA-Z]{3}[0-9]{3}$");
        }
    }
