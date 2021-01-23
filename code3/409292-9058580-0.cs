    //This DLL you've got to add under Project-> Add Reference --> COM Tab --> Lotus Domino Objects
    //Standard Path for this DLL is: "C:\Program Files\Notes\domobj.tlb"
    using Domino;   //domobj.tlb*
    ...
    try
    {
        //-------------------------------------------
        //!!Important!!
        //Before you start, you have to check 2 things
        //1.) Lotus Notes has to run when you start this application
        //2.)The files "notes.ini" and "user.id" 
        // has to be in the main Lotus Notes folder
        //--------------------------------------------    
        
        //First, create a new Lotus Notes Session Object
        Domino.NotesSession LNSession = new Domino.NotesSession();
        //Next add a Database and a Document Object (not new)
        Domino.NotesDatabase LNDatabase;
        Domino.NotesDocument LNDocument;
        //Initialize your Session with your Password
        LNSession.Initialize("password");
        
        //Connect to your Notes Server and the path of your 
        //.nsf File (in my case its in a subfolder 'mail').
        LNDatabase = LNSession.GetDatabase("Notes-Server", "mail\\user.nsf", false);
        //Create an in memory document in the server database
        LNDocument = LNDatabase.CreateDocument();
        //-------Assign Field Values-------
        //Define Start&End Date+Time of your appointment
        //Year, Month, Day, Hour, Minute and Second
        System.DateTime StartDate = new DateTime(2008, 3, 19, 8, 2, 0);
        System.DateTime EndDate = new DateTime(2008, 3, 19, 8, 5, 0);
        //This Defines that it is an Calendar Entry
        LNDocument.ReplaceItemValue("Form", "Appointment");
        //Type of the appointment, means:
        LNDocument.ReplaceItemValue("AppointmentType", "0");
        //0 = Date, Appointment           
        //1 = Anniversary
        //2 = All Day Event (Do Not Set Time Here!)
        //3 = Meeting
        //4 = Reminder
        //5 = Date (Special, experimental!)    
        // Title of your entry
        LNDocument.ReplaceItemValue("Subject", "hello world");
     
        // Set Confidential Level (Public=1 or Private=0) 
        LNDocument.ReplaceItemValue("$PublicAccess","1");    
     
        //Add Start&End Time of your event
        LNDocument.ReplaceItemValue("CALENDARDATETIME", StartDate);
        LNDocument.ReplaceItemValue("StartDateTime", StartDate);
        LNDocument.ReplaceItemValue("EndDateTime", EndDate);
        LNDocument.ReplaceItemValue("StartDate", StartDate);
        LNDocument.ReplaceItemValue("MeetingType", "1");
        //Infos in The Body
        LNDocument.ReplaceItemValue("Body", "Body Text Body Text ...");
        //Add an alarm to your appointment
        LNDocument.ReplaceItemValue("$Alarm", 1);
        LNDocument.ReplaceItemValue("$AlarmDescription", "hello world (alarm)");
        LNDocument.ReplaceItemValue("$AlarmMemoOptions", "" );
        //5 = Time (in minutes) before alarm goes on
        LNDocument.ReplaceItemValue("$AlarmOffset", 5);
        LNDocument.ReplaceItemValue("$AlarmSound", "tada");
        LNDocument.ReplaceItemValue("$AlarmUnit", "M");
        //This saves your Document in the Notes Calendar
        LNDocument.ComputeWithForm(true, false);
        LNDocument.Save(true, false, false);
        //On success, you'll see an info message;
        MessageBox.Show("Calendar Entry Successfully Added!", "Info", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception e1)
    {
        //On error you'll see an error message
        MessageBox.Show(e1.Message);
    }
    ...
