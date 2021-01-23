        public class Note {
           public int SubjectID {get;set;}
           public string Name {get;set;}
        }
        
        //get UNOTE logic here...
        // then add unote to List. Repeat for other types.
        
        var note = new Note() {
           SubjectID = unote.SubjectID,
           Name = unote.Name,
        };
        
        noteList.Add(note);
