    class PBRoomDate {
      // Helper data holder class. Could probably be an anonymous class in C# 4.0
      public PictureBox PB;
      public Label RoomLabel;
      public TextBox DateText;
      PBRoomDate(PictureBox PB, Label RoomLabel, TextBox DateText) {
        this.PB = PB; this.RoomLabel = RoomLabel; this.DateText = DateText;
      }
    }
    // [...]
    
    var pbRoomDates = new PBRoomDate[]{
      new PBRoomDate(pictureBox1, lbl_roomid1, txt_sdate1),
      new PBRoomDate(pictureBox2, lbl_roomid2, txt_sdate2),
      new PBRoomDate(pictureBox3, lbl_roomid3, txt_sdate3),
      // etc.
    };
    
    foreach(var pbRoomDate in pbRoomDates) {
      if(pbRoomDate.PB.Tag.ToString() == "accept") {
        row1[13] = (byte)Convert.ToChar(pbRoomDate.RoomLabel.Text);
        DateTime dt = DateTime.Parse(pbRoomDate.DateText.Text);
      }
    }
