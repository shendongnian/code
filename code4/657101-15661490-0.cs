    bool IsDate(string Input)
        {
            DateTime RV;
            return DateTime.TryParse(Input, out RV);
        }
