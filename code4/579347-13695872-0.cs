    public partial class _Default : Page
    {
      //Used to store generated data.
      List<Room> Rooms = new List<Room>();
      protected void Page_Load(object sender, EventArgs e)
      {
        if (!IsPostBack)
        {
          //To simulate the datasource
          GenerateData();
          //Generate the output
          GenerateTable();
        }
      }
      private void GenerateData()
      {
        //Generate Rooms
        foreach (var roomNumber in Enumerable.Range(7, 4))
        {
          var newRoom = new Room();
          newRoom.RoomID = roomNumber;
          newRoom.Roomname = "Room " + roomNumber.ToString();
          //Generate 40 15-minute time slot appointments for each room
          for (var count = 0; count < 40; ++count)
          {
            var newAppointment = new Appointment();
            newAppointment.Id = (roomNumber * 40) + count;
            newAppointment.Name = " ";
            newAppointment.NumberOfTimeSlots = 1;
            newRoom.Appointments.Add(newAppointment);
          }
          Rooms.Add(newRoom);
        }
        Rooms[0].Appointments[0].Name = "John";
        Rooms[0].Appointments[0].NumberOfTimeSlots = 1;
        Rooms[0].Appointments[2].Name = "John";
        Rooms[0].Appointments[2].NumberOfTimeSlots = 3;
        Rooms[1].Appointments[14].Name = "calc";
        Rooms[1].Appointments[14].NumberOfTimeSlots = 3;
        //More can be added
      }
      private void GenerateTable()
      {
        //Moved outside of the loop since it is globally setting the table and does not need to run for each row.
        tableAppointment.Style.Add("table-layout", "fixed");
        /**********************************************************************************************
         * Major change 1:
         * I flipped the order of the loops, I changed it from row->column to column->row.
         * What this allows you to do is skip the step of adding additional rows for the current room
         * by increment the row counter (not a good practice, need to refactor code).
         **********************************************************************************************/
        //You had: foreach(DataRow dr in dataTableAcqModality.Rows) {
        //I am assuming that this is a list of rooms to display
        foreach (var dr in Rooms)      
        {
        
          for (int i = 0; i < tableAppointment.Rows.Count; ++i)
          {
            var cell = new HtmlTableCell();
            cell.Style.Add("word-wrap", "break-word");
            cell.Attributes.Remove("class");
            cell.Attributes.Remove("rowspan");
            cell.Style.Remove("display");
            tableAppointment.Rows[i].Cells.Add(cell);
            if (i == 0) //Indicating the header row
            {
              cell.Attributes.Add("ID", dr.RoomID.ToString());
              cell.InnerHtml = String.Format(
                  "<span id='{0}'>{1}</span>",
                  dr.RoomID, dr.Roomname
              );
              tableAppointment.Rows[0].Attributes.Add("class", "csstextheader");
            }
            else
            {
              /***********************************************************************
               * Assumption that this is how you are adding the appointments to the 
               * table, did not see it in your quesiton
               ***********************************************************************/ 
              //i-1 to offset the header row
              cell.InnerHtml = dr.Appointments[i-1].Name;
              //NumberOfTimeSlots does not have to be part of the object, you are already doing it one way (not shown)
              cell.RowSpan = dr.Appointments[i - 1].NumberOfTimeSlots;
              //This is the inportant part, incrementing the row counter for this table by the number of cells you need to be removed becasue of the rowspan.
              //NOTE: I do not like the idea of messing with a loop counter, I would try to refactor your code, but since it was not provided this is a temporary fix.
              i += dr.Appointments[i - 1].NumberOfTimeSlots - 1;
            }
          }
        }
      }
    }
    public class Room
    {
      public int RoomID { get; set; }
      public string Roomname { get; set; }
      public List<Appointment> Appointments { get; set; }
      public Room()
      {
        Appointments = new List<Appointment>();
      }
    }
    public class Appointment
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public int NumberOfTimeSlots { get; set; }
    }
