      if (user != null)
            {
                photo = user.Photo== null ? null : (byte)user.Photo;
                email = user.Email;
                userID = user.UserID;
                return true; // success!
            }
            else
            {
                return false;
            }
