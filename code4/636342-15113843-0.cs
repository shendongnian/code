    private async Task ProcessProofOfPressenceImages(Dictionary<object, object> container, List<Dictionary<string, string>> images, string surveyReference)
    {
      if(images != null)
      {
        await Task.WhenAll(this.ProcessImagesHelper(container, images, surveyReference, "propertyImage"));
      }
    }
