    progressBar.Value = 0;
    //phase 1
    foreach (SomeObject step1Object in step1Objects) {
        // Build step2Objects
        progress = progress + step2Objects.Count;
        progressBar.Value = progress;
    }
    
    //phase 2
    foreach (SomeObject step2Object in step2Objects) {
        // Do something
        progress = progress + step1Objects.Count;
        progressBar.Value = progress;
    }
