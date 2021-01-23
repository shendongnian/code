    void ValidateRoomGender() 
    {
         if(string.IsNullOrEmpty(roomGender))
         {
             vldRoomGender = "Please enter a room gender";
         }
         else if ((roomGender != 'M') && (roomGender != 'F'))
         {
             vldRoomGender = "Invalid Value";
         }
         else
         {
             vldRoomGender = string.Empty;
         }
    }
    void ValidateGender() 
    {
         if( ((vldGender == 'F') && (vldRoomGender == 'M')) || ((vldGender == 'M') && (vldRoomGender == 'F'))
         {
              vldGender = "The gender must match the room"
         }
         else if (string.IsNullOrEmpty(vldGender))
         {
            // etc
         }
    }
    void Validate()
    {
          ValidateRoomGender();
          ValidateGender();
          ValidateFirstName();
          ValidateSurname();
    }
