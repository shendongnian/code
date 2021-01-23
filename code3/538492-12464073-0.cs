    List<NoteView> notes = new List<NoteView>();
    
    protected void Button1_Click(object sender, RoutedEventArgs e)
    {
       notes.Add(new NoteView {
          a = "text one",
          b = "whatevs",
          c = "yawns"
       });
    NotesList.DisplayMember = "a";
            NotesList.ValueMember = "b";
       NotesList.ItemsSource = notes;
    }
     
