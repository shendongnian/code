        //I like min length set to 3, to not give too many options 
        //after the first character or two the user types
        public Int32 AutoCompleteMinLength {get; set;}
        private void HandleTextChanged() {
            var txt = comboBox.Text;
            if (txt.Length < AutoCompleteMinLength)
                return;
            //The GetMatches method can be whatever you need to filter 
            //table rows or some other data source based on the typed text.
            var matches = GetMatches(comboBox.Text.ToUpper());
            if (matches.Count() > 0) {
                //The inside of this if block has been changed to allow
                //users to continue typing after the auto-complete results
                //are found.
                comboBox.Items.Clear();
                comboBox.Items.AddRange(matches);
                comboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                comboBox.Select(txt.Length, 0);
                return;
            }
            else {
                comboBox.DroppedDown = false;
                comboBox.SelectionStart = txt.Length;
            }
        }
