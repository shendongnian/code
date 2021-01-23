        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox m_texti2cWrite = (TextBox)sender;
            int count = 0;
            string text1 = m_texti2cWrite.Text;
            string text = m_texti2cWrite.Text.Replace(" ", string.Empty);
            string hexString = string.Empty;
            int countCaret = e.Changes.ToList()[0].Offset;
            for (int i = 0; i < text.Length; i++)
            {
                hexString += text[i];
                if ((i + 1) % 2 == 0)
                {
                    if (i != text.Length - 1)
                    {
                        hexString = hexString + " ";
                        count++;
                    }
                }
                count++;
            }
            m_texti2cWrite.Text = hexString;
            if (text1.Length == countCaret)
            {
                m_texti2cWrite.Select(count, 0);
            }
            else
            {
                m_texti2cWrite.Select(countCaret, 0);
            }
        }
    }
