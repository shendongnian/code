using System.Text.RegularExpressions;
    Match mDate = Regex.Match(e.Brick.Text, @"\b(?<date>(\d{1,2}[\\/-]){2}\d{4})\b", RegexOptions.Compiled);
    if (mDate.Success)
    {
        MessageBox.Show(string.Format("Date: {0}", mDate.Groups["date"].Value));
    }
