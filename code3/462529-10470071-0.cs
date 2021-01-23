I used regular expressions, hope that's not a problem. The regex detect the /Date(NUMBER)/\ and gets the NUMBER as a group in the regular expression match so I use that to replace everything in the dateTimeJson that matches the regex specified in its constructor with new Date(NUMBER).
            //the source JSON
            string dateTimeJson = "/Date(1336258800000)/\\";
            string result = "";
            //you might want to do a quick IndexOf("Date") to make sure that there is a date
            //so you won't trouble yourselve with regex computation unnecessarily. performance?
            //find Date(NUMBER) matches and get the NUMBER then use it again with new Date in the 
            //call to replace
            System.Text.RegularExpressions.MatchCollection matches = null;
            System.Text.RegularExpressions.Regex regex = null;
            try
            {
                //at the end is one forwared slash for regex escaping \ and another is the \ that is escaped
                regex = new System.Text.RegularExpressions.Regex(@"/Date\(([0-9]*)\)/\\");
                matches = regex.Matches(dateTimeJson);
                string dateNumber = matches[0].Groups[1].Value;
                result = regex.Replace(dateTimeJson, "new Date(" + dateNumber + ")");
            }
            catch (Exception iii)
            {
                //MessageBox.Show(iii.ToString());
            }
            MessageBox.Show(result);
