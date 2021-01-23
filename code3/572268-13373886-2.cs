    static void CreateNewSectionMeetingsInWorkNotebook()
        {
            String strID;
            OneNote.Application onApplication = new OneNote.Application();
            onApplication.OpenHierarchy("C:\\Documents and Settings\\user\\My Documents\\OneNote Notebooks\\Work\\Meetings.one", 
            System.String.Empty, out strID, OneNote.CreateFileType.cftSection);
        }
