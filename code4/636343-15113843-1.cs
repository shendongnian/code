    private Task ProcessProofOfPressenceImages(Dictionary<object, object> container, List<Dictionary<string, string>> images, string surveyReference)
    {
      if(images != null)
      {
        return Task.WhenAll(this.ProcessImagesHelper(container, images, surveyReference, "propertyImage"));
      }
      return Task.FromResult<object>(null);
    }
