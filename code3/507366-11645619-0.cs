    progressBar.Maximum = 100;
   
    var stepPercentage = 100 / step1Objects.Count;
    foreach(SomeObject step1Object in step1Objects)
    {
        progressBar.Progress += stepPercentage;
    }
    progressBar.Progress = 50;
    foreach(SomeObject step2Object in step2Objects)
    {
        progressBar.Progress += (stepPercentage + 50);
    }
     
