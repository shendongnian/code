    [HttpGet]
    public FileResult GetImage(int evaluatorId, int employeeId)
    {
        byte[] imgByteArr = this._employeeManager.GetEmployeePhoto(employeeId);
        return imgByteArr != null ? File(imgByteArr, "image/png") : null;
    }
