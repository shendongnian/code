    private void comboCode_TextType(object sender, EventArgs e)
        {
            int itemsIndex = 0;
            foreach (string item in cmbGageCode.Items)
            {
                if (item.IndexOf(cmbGageCode.Text) == 0)
                {
                    cmbGageCode.SelectedIndex = itemsIndex;
                    cmbGageCode.Select(cmbGageCode.Text.Length - 1, 0);
                    break;
                }
                itemsIndex++;
            }
        }
