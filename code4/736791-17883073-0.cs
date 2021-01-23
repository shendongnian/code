    int num = 0;
    if (int.TryParse(number.Text, out num) && num > 0 && num < 455)
    {
        string site;
        site = number.Text;
        var rs = Application.GetResourceStream(new Uri("def/f" + site + ".html", UriKind.Relative));
        StreamReader sr = new StreamReader(rs.Stream);
        browser.NavigateToString(sr.ReadToEnd());
    }
    else
    {
        MessageBox.Show("Enter Value between 1 to 454");
    }
