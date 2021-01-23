       private void button20_Click_1(object sender, EventArgs e)
        {
            scintilla1.GetRange().ClearIndicator(2);
            scintilla1.Indicators[2].Style = IndicatorStyle.Box;
            scintilla1.Indicators[2].Color = Color.Cyan;
            try
            {
                Line next = scintilla1.Markers.FindNextMarker(); //replace with previous to get the previous on the control bookmark
        
                scintilla1.Caret.Position = next.EndPosition;
                next.Range.SetIndicator(2);
                scintilla1.Caret.Goto(next.EndPosition);
                scintilla1.Focus();        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No more marks.. " + ex.Message);
            }
        }
