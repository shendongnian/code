    Match match = Regex.Match(tdInnerHtml, @"(\d+) Points");
    if (match.Success){
      // fetch result
      String pointsString = match.Groups[1].Value;
      // optional: parse to integer
      Int32 points;
      if (Int32.TryParse(pointsString, out points)){
        // you now have an integer value
      }
    }
