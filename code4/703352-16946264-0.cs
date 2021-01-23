    class Currency {
        public string currency_code { get; set; }
        public float unit { get; set; }
        public string currency_name { get; set; }
        public string currency_isim { get; set; }
        public float forex_buying { get; set; }
        public float forex_selling { get; set; }
        public float banknote_buying { get; set; }
        public float banknote_selling { get; set; }
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(currency_code + ", ");
            sb.Append(unit.ToString() + ", ");
            sb.Append(currency_name + ", ");
            sb.Append(currency_isim + ", ");
            sb.Append(forex_buying.ToString() + ", ");
            sb.Append(forex_selling.ToString() + ", ");
            sb.Append(banknote_buying.ToString() + ", ");
            sb.Append(banknote_selling.ToString());
            return sb.ToString();
        }
    }
