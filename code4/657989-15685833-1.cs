        public class IntegerTextBox : TextBox
        {
        private Keys[] int_allowed = {
                 Keys.D1,
                 Keys.D2,
                 Keys.D3,
                 Keys.D4,
                 Keys.D5,
                 Keys.D6,
                 Keys.D7,
                 Keys.D8,
                 Keys.D9,
                 Keys.D0,
                 Keys.NumPad0,
                 Keys.NumPad1,
                 Keys.NumPad2,
                 Keys.NumPad3,
                 Keys.NumPad4,
                 Keys.NumPad5,
                 Keys.NumPad6,
                 Keys.NumPad7,
                 Keys.NumPad8,
                 Keys.NumPad9,
                 Keys.Back,
                 Keys.Delete,
                 Keys.Tab,
                 Keys.Enter,
                 Keys.Up,
                 Keys.Down,
                 Keys.Left,
                 Keys.Right
            };
         protected override void OnKeyDown(KeyEventArgs e)
                {
                    base.OnKeyDown(e);
                    if (e.Modifiers == Keys.Control) return;
        
                    if (!int_allowed.Contains(e.KeyCode))
                    {
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }
    
