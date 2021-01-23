            string comment = "04/05/11 17:10:19 (user2):Work Log - Closing.";
            string dateSection = comment.Substring(0, 17);
            DateTime date;
            if (!DateTime.TryParse(dateSection, out date))
            {
                throw new Exception(string.Format("unable to parse string '{0}'", dateSection));
            }
