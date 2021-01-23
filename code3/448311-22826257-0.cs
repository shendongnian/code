            string name;
            int letter;
            name = TxtInput.Text;
            for (int index = 0; index < name.Length; index++)
            {
                letter = name[index];
                MessageBox.Show(letter.ToString());
            }
        }
