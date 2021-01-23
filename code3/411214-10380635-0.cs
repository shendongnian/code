        private void scintillaCs_CharAdded(object sender, ScintillaNET.CharAddedEventArgs e)
        {
            ScintillaNET.Scintilla editor = sender as ScintillaNET.Scintilla;
            if (e.Ch == '.')
            {
                Timer t = new Timer();
                t.Interval = 10;
                t.Tag = editor;
                t.Tick += new EventHandler((obj, ev) =>
                {
                    // make a new autocomplete list if needed
                    List<string> s = new List<string>();
                    s.Add("test");
                    s.Add("test2");
                    s.Add("test3");
                    s.Sort(); // don't forget to sort it
                    editor.AutoComplete.ShowUserList(0, s);
                    t.Stop();
                    t.Enabled = false;
                    t.Dispose();
                });
                t.Start();
            }
        }
    }
