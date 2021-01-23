    class MeetingManager
    {
    	...
    
    	//add and implement a find method which returns a Meeting-object if there is a
     //corresponding meeting date (in private Meeting[] meetings;)
    	public Meeting MeetingFinder(DateTime meetingTime)
    	{
    		//if there is a corresponding meeting-object for the date, return the meeting object
    		//if there isn't, return null
    	}
    
    	...
    }
----------
    public partial class CalendarForm : Form
    {
    
    	...
    
    	private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
    	{
    		//which date was selected?
          		var selectedDate = monthCalendar.SelectionRange.Start;
    
    	
    		//do we have that date in the meetings?
    		var meetingOnTheSelectedDate = mManager.MeetingFinder(selectedDate);
    
    		if(meetingOnTheSelectedDate != null)
    		{
    			//populate your winform with the data from meetingOnTheSelectedDate
    		}
    	}
    
    	...
    
    }
