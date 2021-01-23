      DataTable dt = dbConn.GetSchema("Restrictions");
      AppLog.Log.Info("CollectionName | RestrictionName | ParameterName | " +
                      "RestrictionDefault | RestrictionNumber");
      AppLog.Log.Info(" ");
      foreach (DataRow r in dt.Rows) {
          String s = r["CollectionName"] as String;
          s += " | " + r["RestrictionName"] as String;
          s += " | " + r["ParameterName"] as String;
          s += " | " + r["RestrictionDefault"] as String;
          s += " | " + r["RestrictionNumber"].ToString();
          AppLog.Log.Info(s);
      }
