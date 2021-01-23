    public static string ToCsv(this object obj)
    {
        return string.Join(
            this.GetType().GetProperties().Select(pi=>
                Escape(pi.GetValue(this, null).ToString())
            ));
    }
