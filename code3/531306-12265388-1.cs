    public ActionResult MillRequestCoil()
    {
        return MyHelperClass.SafeViewFromModel(model =>
        {
            string coilId = "CC12345";
            model.Data = new {
                Coil = coilId,
                M3 = "m3 message",
                M5 = "m5 message" };
            model.Message = string.Format("Coil {0} sent successfully", coilId);
        });
    }
