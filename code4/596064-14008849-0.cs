    DateTime dt = new DateTime();
    dt = DateTime.Now;
    DateTime newdt = new DateTime();
    TimeSpan tim = new TimeSpan(120,0,0,0,0);
    newdt = dt.Add(tim);
    MessageBox.Show(newdt.ToString());
