    count++;
    label5.Text = count.ToString("X2");
    DateTime time = DateTime.Now;
    s = "4D-" + "1A-" + "2B-" + "3C-" + label5.Text;
    s = s.Replace('-', ' ');
    string[] strings = s.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
    List<int> ints = strings.Select(a => int.Parse(a,System.Globalization.NumberStyles.AllowHexSpecifier)).ToList<int>();
    int xor = ints[0];
    for(int i=1;i<ints.Count;i++)
    {
          xor ^= ints[i];
    }
    txtSend.Text = s + " (" + xor.ToString("X2") + ")";
