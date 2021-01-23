    string string1 = GetReallyLongString();
    const int sqlMax = 8000;
    while (true) {
        if (string1.Length > sqlMax) {
            SendToSql(string1.Substring(0, sqlMax));
            string1 = string1.Substring(sqlMax);
        } else {
            SendToSql(string1);
            break;
        }
    }
