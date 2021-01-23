    List<string> RCode = DbEntity.MobileAssetDowntimeReasonCodes
        .Where(a=>a.MobileAssetCategoryID.Equals(reasonCode)
        .Select(a=>a.JdeReasonCode).ToList();
    var RJDEReasonCode = JDETable.F0005
        .Where(a=>a.DRSY.Equals("00") && a.DRDL01 != null &&
                 (a.DRRT.Equals("W4") || a.DRRT.Equals("W5")) &&
                  RCode.Any(code => code.Contains(a.DRKY.Trim()))
        .Select(a=>new { CATEGORY_CODE = a.DRRT,
                         REASON_CODE = a.DRKY,
                         DESCRIPTION = a.DRDL01
        });
               
