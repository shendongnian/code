        {
            //The first input
            if (LastKey != Keys.None)
            {
                int combination1 = (int)Enum.Parse(typeof(Keys), cmbCombinationOne.SelectedValue.ToString());
                int combination2 = (int)Enum.Parse(typeof(Keys), cmbCombinationTwo.SelectedValue.ToString());
                
                int LastKeyPress = (int)Enum.Parse(typeof(Keys), LastKey.ToString());
                ThisKey = e.Key;
                if (combination1 == LastKeyPress && combination2 == Convert.ToInt32(ThisKey))
                {
                    MessageBox.Show("Key pressed");
                }
            }
            LastKey = e.Key;
        }
