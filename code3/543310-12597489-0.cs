          start = emailbody.IndexOf("To:");
                            if (start < 0)
                                start = 0;
                           
         string emailExpression = @"([a-zA-Z0-9_\.]+)@([a-zA-Z0-9_\.]+)\.([a-zA-Z]{2,3})";
          System.Text.RegularExpressions.Regex regExp = new System.Text.RegularExpressions.Regex(emailExpression);
                            if (regExp.IsMatch(eamilbody, start))
                   {
                         System.Text.RegularExpressions.Match match = regExp.Match(emailbody, start);
                                string email = match.Value;
                     }
