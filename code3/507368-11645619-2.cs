    progressBar.Maximum = 100;
   
    var stepPercentage = 50 / step1Objects.Count;
    foreach(SomeObject step1Object in step1Objects)
    {
        progressBar.Progress += stepPercentage;
    }
    progressBar.Progress = 50;
    stepPercentage = 50 / step2Objects.Count;
    foreach(SomeObject step2Object in step2Objects)
    {
        progressBar.Progress += (stepPercentage + 50);
    }
     
