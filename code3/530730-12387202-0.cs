      if (user != null)
            {
                photo = (byte)user.Photo;
                email = user.Email;
                userID = user.UserID;
                return true; // success!
            }
            else
            {
                return false;
            }
