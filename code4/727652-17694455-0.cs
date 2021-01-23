    public partial class RoomBooking : Form
    {
        public RoomBooking() // WinForms Designer requires a public parameterless constructor
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        public RoomBooking(string roomNumber) : this() // Constructor chaining
        {
            RoomNumber = roomNumber;
            txtRoomNum.Text = RoomNumber;
        }
        public string RoomNumber { get; set; }
    }
