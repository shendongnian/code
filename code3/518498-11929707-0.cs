    You can use subtract method as
    DateTime myDate1 = new DateTime(1970, 1, 9, 0, 0, 00);
    DateTime myDate2 = DateTime.Now;
    TimeSpan ts = myDate2.Subtract(myDate1);
    MessageBox.Show(ts.TotalSeconds.ToString());
