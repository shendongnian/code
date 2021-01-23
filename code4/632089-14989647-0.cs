    public partial class CalendarForm : Form
    {
      private List<Meeting> Meetings { get; set; }
      public CalendarForm()
      {
        InitializeComponent();
        Meetings = new List<Meeting>();
      }
      private void saveChangesButton_Click(object sender, EventArgs e)
      {     
        try 
        {       
          Meeting meeting = CreateMeeting();
          Meetings.Add(meeting);
          meetingListBox.Add(meeting);
        }
        catch
        {
          //Add proper error handling here
        }            
      }
      private Meeting CreateMeeting()
      {
        return new Meeting()
        {
          Title = textBoxTitle.Text,
          Location = textBoxLocation.Text
          StartTime = DateTime.Parse(textBoxStartTime.Text),
          EndTime = DateTime.Parse(textBoxEndTime.Text),
          Notes = notesTextBox.Text,
         };
       }
    }
    //As Matt Burland answered already:
    private void meetingListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      Meeting meeting = meetingListBox.SelectedItem as Meeting;
      if (meeting != null) 
      {
        textBoxTitle.Text = meeting.Title;
        //...etc for all your other text boxes.
      }
    }
    public class Meeting
    {
      public string Title { get; set; }
      public string Location  { get; set; }
      public DateTime StartTime  { get; set; }
      public DateTime EndTime  { get; set; }
      public string Notes  { get; set; }
      public override string ToString()
      {
        return Title; 
      }
    }
