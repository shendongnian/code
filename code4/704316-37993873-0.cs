    public ActionResult GetInfo(string sUserInput)
    {
        var result = sUserInput.IsInt
            ? GetInfoByInt(int.Parse(sUserInput))
            : GetInfoByString(sUserInput)
        return result;
    }
