    var checkinNoteFieldValues = new[]
    {
        new CheckinNoteFieldValue("Custom Note", "some value"),
        new CheckinNoteFieldValue("Other Note", "other value")
    };
    var checkinNote = new CheckinNote(checkinNoteFieldValues);
    var pendingChanges = workspace.GetPendingChanges(); // workspace is Microsoft.TeamFoundation.VersionControl.Client.Workspace
    workspace.CheckIn(pendingChanges, "comment", checkinNote, null, null); // checkinNote will trigger a new CheckinNoteFieldDefinition 
