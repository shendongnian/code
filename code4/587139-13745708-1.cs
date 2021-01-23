    bool IsValid(List<double> contents) {
      //Get the distinct whole numbers (let's call a whole number a "chapter")
      var wholeNumbers = contents.Select(t => Math.Floor(t)).Distinct();
      foreach (var num in wholeNumbers) {
        //Get the "subcontents" for this whole number (chapter)
        var subContents = wholeNumbers.Where(t => Math.Floor(t) == num).ToList();
        for (int i = 0; i < subContents.Count() - 1; i++) {
          //If the subcontents are different by something other than 0.1, it's invalid
          if (subContents.Count() > 1 && subContents[i + 1] - subContents[i] != 0.1) {
            return false;
          }
        }
      }
      return true;
    }
