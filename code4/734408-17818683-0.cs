    var allowed = new[] { 'ö', 'ä' };
    var isOK = textBox1.Text.All(c =>
        char.GetUnicodeCategory(c) == UnicodeCategory.LowercaseLetter ||
        char.GetUnicodeCategory(c) == UnicodeCategory.UppercaseLetter ||
        char.GetUnicodeCategory(c) == UnicodeCategory.DecimalDigitNumber ||
        allowed.Contains(c));
