            foreach (int roomN in NameRoom)
            {
                if (dictionary.ContainsKey(roomN))
                {
                    string buttonName = dictionary[roomN];
                    Control[] matches = this.Controls.Find(buttonName, true);
                    if (matches.Length > 0 && matches[0] is Button)
                    {
                        Button button = (Button)matches[0];
                        button.Image = ((System.Drawing.Image)(Properties.Resources.Merdivan));
                    }
                }
            }
