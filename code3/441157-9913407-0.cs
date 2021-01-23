    private void MyRTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (e.Key == Key.B) 
                {
                    MakeBold();
                }
                else if (e.Key == Key.I)
                {
                    MakeItalic();
                }
                else if (e.Key == Key.U)
                {
                    Underline();
                }
            }
        }
