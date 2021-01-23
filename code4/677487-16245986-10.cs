     client.GetCompleted += (o, e) =>
             {
                 // some code
                 if (Convert.ToInt64(eargs.Result) == 0)
                 {
                   UserID = Convert.ToInt64(eargs.Result);
                 }
                 // your logic here
                 if (UserID == -1)
                      // WRONG RESULT <---
                 else
                      // RIGHT RESULT <---
             }
