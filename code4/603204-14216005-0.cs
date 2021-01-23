    var a =  (from app in mamDB.Apps where app.IsDeleted == false 
             select new {app.AppName, app.AppsData.IsExperimental})
             .AsEnumerable()
             .Select(row => string.Format("{0}{1}",
                row.AppName, row.IsExperimental ? " (exp)" : "")).ToArray();
