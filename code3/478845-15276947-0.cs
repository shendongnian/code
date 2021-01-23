        private void DpStartPowerPoint()
    {
        // Create the reference variables
        PowerPoint.Application ppApplication = null;
        PowerPoint.Presentations ppPresentations = null;
        PowerPoint.Presentation ppPresentation = null;
    
        // Instantiate the PowerPoint application
        ppApplication = new PowerPoint.Application();
    
        // Create a presentation collection holder
        ppPresentations = ppApplication.Presentations;
    
        // Create an actual (blank) presentation
        ppPresentation = ppPresentations.Add(Office.MsoTriState.msoTrue);
    
        // Activate the PowerPoint application
        ppApplication.Activate();
    }
