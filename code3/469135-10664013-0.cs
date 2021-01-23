    // Convert Persian Calendar date to regular DateTime
    var persianDateMatch = System.Text.RegularExpressions.Regex.Match(
        persianTargetTextBox.Text, @"^(\d+)/(\d+)/(\d+)$");
    var year = int.Parse(persianDateMatch.Groups[1].Value);
    var month = int.Parse(persianDateMatch.Groups[2].Value);
    var day = int.Parse(persianDateMatch.Groups[3].Value);
    var pc = new System.Globalization.PersianCalendar();
    var target = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
    var difference = target - DateTime.Today;
    differenceLabel.Text = difference.TotalDays.ToString("0");
