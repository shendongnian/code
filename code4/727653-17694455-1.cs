    public partial class AvailableRooms : Form
    {      
        private void DCRoom(object sender, DataGridViewCellMouseEventArgs e)
        {
            var roomNumber = dgRooms.Rows[e.RowIndex].Cells["iRoomNum"].Value.ToString();
            var roomBooking = new RoomBooking(roomNumber);
            roomBooking.Show();
        }
    }
