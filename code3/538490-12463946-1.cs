            List<NoteView> notes = new List<NoteView>();
            notes.Add(new NoteView { Item = "a", Value = 1 });
            notes.Add(new NoteView { Item = "b", Value = 2 });
            notes.Add(new NoteView { Item = "c", Value = 3 });
            listBox1.DataSource = notes;
            listBox1.DisplayMember = "Item";
            listBox1.ValueMember = "Value";
