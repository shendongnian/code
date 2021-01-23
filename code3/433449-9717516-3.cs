    foreach(string line in lines) {
          string[] pair = line.Split(new[] {':'});
          string key = pair[0].Trim();
          string val = pair[1].Trim();
          ....
       }
