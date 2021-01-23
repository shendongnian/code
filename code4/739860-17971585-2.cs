    var resultObject = new ResultObject {
        Conditions =
            (oldResultObject.AlphaValue ? Conditions.ByAlpha : Conditions.ByNone) | 
            (oldResultObject.BetaValue ? Conditions.ByBeta : Conditions.ByNone) |
            (oldResultObject.GammaValue ? Conditions.ByGamma : Conditions.ByNone),
        Name = oldResult.Name;
    }
