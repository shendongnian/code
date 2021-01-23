    public class MailingListSaver
    {
       public static void Save(EmailMailingList ml)
       {
          //insert (ml.EmailList) into database
       }
    }
    //Use:
    EmailMailingList ml = new EmailMailingList();
    ml.EmailList = "blah";
    MailingListSaver.Save(ml);
