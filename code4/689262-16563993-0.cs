    public ActionResult TestAction(string Destination)
    {
         SampleViewModel sampleViewModel = new SampleViewModel();
         var value = typeof(SampleViewModel).GetProperty(Destination).GetValue(sampleViewModel);
    }
