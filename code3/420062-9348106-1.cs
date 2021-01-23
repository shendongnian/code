    public ActionResult PutInBin(int captureId)
    {
        QueryCaptureToBin queryCaptureToBin = new QueryCaptureToBin();
        queryCaptureToBin.Capture_Id = captureId;
        client.PlaceCaptureInBin(queryCaptureToBin, userParams);
        return new EmptyResult();
    }
