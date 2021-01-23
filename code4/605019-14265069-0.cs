    Datetime start;
    DateTime end;
    if (DateTime.TryParse(txtDateStart.Text, out start)
      && DateTime.TryParse(txtDateEnd.Text, out end))
    {
      DateTime now = DateTime.Now;
      cmbo.Text = (now > start || now < end // inline ternary
        ? "EXPIRED"                         // true value
        : "CURRENT"                         // false value
      );
    }
    else { /* Error */ }
