            private void send_Click(object sender, EventArgs e)
        {
            if (entryBox.Text != "")
            {
                listData.Add(entryBox.Text);
                // Remove the linebreak caused by pressing return
                SendKeys.Send("\b");
                // Empty the array string
                ArrayData = "";
                foreach (string textItem in listData)
                {
                    ArrayData = ArrayData + "You >> " + textItem + "\r\n";
                }
                entryBox.Focus();
                displayBox.Text = "";
                displayBox.Refresh();
                displayBox.Text = ArrayData;
                // Format the "You >>"
                displayBox.SelectionStart = 0;
                displayBox.SelectionLength = 6;
                displayBox.SelectionFont = new Font(displayBox.Font, FontStyle.Bold);
                displayBox.SelectionColor = Color.Crimson;
                displayBox.SelectionLength = 0;
                string wordToFind = "You >>";
                int startIndex = 0;
                while (startIndex > -1)
                {
                    startIndex = displayBox.Find(wordToFind, startIndex + 1,
                                    displayBox.Text.Length,
                                    RichTextBoxFinds.WholeWord);
                    if (startIndex > -1)
                    {
                        displayBox.Select(startIndex, wordToFind.Length);
                        displayBox.SelectionFont = new Font(displayBox.Font, FontStyle.Bold);
                        displayBox.SelectionColor = Color.Crimson;
                    }
                }
                // Reset the entry box to empty
                entryBox.Text = "";
                
            }
            // Remove the linebreak caused by pressing return
            SendKeys.Send("\b");
        }
