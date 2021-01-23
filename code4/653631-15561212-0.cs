    string GetWarehousByGrade222(string grade, string paste)
    {
      if (grade == "00" || grade == "01" || grade == "02" || grade == "03" || grade == "04") {
        if (Regex.IsMatch(paste, "D..G..DG")) return "1GD";
        if (Regex.IsMatch(paste, "D..G..DP")) return "1GD";
        if (Regex.IsMatch(paste, "D..G..D.")) return "1GO";
        // etc...
      }
      return null;
    }
