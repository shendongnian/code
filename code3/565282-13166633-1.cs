    string input = "3030313535333635";
    var sb = new StringBuilder(8); // Specify capacity = 8
    for (int i = 1; i < 16; i += 2) {
        sb.Append(input[i]);
    }
    string result = sb.ToString();
