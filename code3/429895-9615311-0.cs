                string IdWithNote = string.Empty;
                string noteList = Properties.Settings.Default.FavoriteNotesList;//your string type note list
                List<string> listNote = new List<string>();//newly created string type collection
                listNote=noteList.Split(',').ToList<string>();
                int index=listNote.IndexOf("'" + id + ":");
                if (index > -1)
                    IdWithNote = listNote[index];
                return IdWithNote;
