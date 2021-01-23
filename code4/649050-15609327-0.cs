    public class Cleaner : IOutlookPstCleaner 
    {
        public void Cleanup(IOutlookFolderParameters folders)
        {
            var email = folders.EmailFolder;
            var task = folders.TaskFolder;
            var appointment = folders.AppointmentFolder;
        }
    }
