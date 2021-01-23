        int[] intNameIDs = = new int[] { 3, 4, 5 };
        int hid=22;
        public void updateintoRoomNames(int hid,int[] intNameIDs, string[] strResult)
        {
            DA_HotelDetails hd2 = new DA_HotelDetails();
            hd2.updateintoRommNamesDA(hid,intNameIDs, strResult);
        }
        public void updateintoRommNamesDA(int hid,int[] intNameIDs, string[] strResult)
        {
            int nameidIndex = 0;//index for intHids array. 
            foreach (string s in strResult)
            {
                Connection concls = new Connection();
                SqlCommand cmd = new SqlCommand();
                string instr = "update tblRoomNames set roomnames='" + s + "' where nameid=" + intNameIDs[nameidIndex] + " and Hid=" + hid;
                concls.opencon();
                cmd.CommandText = instr;
                concls.executenonquery(cmd);
                concls.closecon();
                nameidIndex++;//move to next.
            }
        }
