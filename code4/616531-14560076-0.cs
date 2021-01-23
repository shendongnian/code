        public void updateintoRommNamesDA(List<Entity_HotelDetails> updatedList)
        {
            
            foreach (Entity_HotelDetails s in updatedList)
            {
                Connection concls = new Connection();
                SqlCommand cmd = new SqlCommand();
                string instr = "update tblRoomNames set roomnames='" + s.ROOMNAMES + "' where nameid=" + s.NAMEID + " and Hid=" + s.HID;
                concls.opencon();
                cmd.CommandText = instr;
                concls.executenonquery(cmd);
                concls.closecon();
               
            }
        }
