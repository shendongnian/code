    public static class ProdStatusExtensions {
        public static string (this ProductionStatus status) {
            return ((int)status).ToString ("000",  CultureInfo.InvariantCulture);
        }
    }
