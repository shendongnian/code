        public bool JoinCalendar(int famID, string email)
        {
            using (var db = new DataContext())
            {
                var exists = db.Users.Any(u => u.familyID == famID && u.emailAddress != email);
                if (exists)
                {
                    return false;
                }
                //stuff
                return true;
            }
        }
