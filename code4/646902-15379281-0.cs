    string[] lines = {DateTime.Now.Date.ToShortDateString(),DateTime.Now.TimeOfDay.ToString(), message, type, module };
              if (!File.Exists(HttpContext.Current.Server.MapPath("~/logger.txt")))
              {
                  System.IO.File.WriteAllLines(HttpContext.Current.Server.MapPath("~/logger.txt"), lines);
              }
              else
              {
                  System.IO.File.AppendAllLines(HttpContext.Current.Server.MapPath("~/logger.txt"), lines);
              }
