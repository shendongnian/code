      public class myComboBox : ComboBox
        {
            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.Key != Key.F4)
                {
                    base.OnKeyDown(e);
                }
            }
        }
