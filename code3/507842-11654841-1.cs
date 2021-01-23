    bool ProcessOrContinue(IEnumerable collection) {
      foreach (var item in collection) {
        if (ShouldContinue(item)) {
          return true;
        }
        // other stuff
      }
      return false;
    }
    
    for (int i = 0; i < blah; i++) {
      if (ProcessOrContinue(collection)) continue;
      // more things
    }
