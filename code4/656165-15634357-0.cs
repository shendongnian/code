    internal static List<ORT> Ort()
    {
        List<ORT> ortObject = new List<ORT>();
        ortObject.Add(new ORT
                      {
                          RegionID="235",
                          RegionName="deutschland",
                          Stadt = new List<STADT>()
                          {
                              new STADT { Stadname="Frankfurt" }
                          }
                      });
        return ortObject;
    }
