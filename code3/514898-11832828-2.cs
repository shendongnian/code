            StringBuilder MessageText = new StringBuilder();
            MessageText.AppendLine(string.Format("Age: {0}", age_Num.Text));
            MessageText.AppendLine(string.Format("Height: {0}", height_Num.Text));
            MessageText.AppendLine(string.Format("Weight: {0}", weight_Num.Text));
            MessageBox.Show(MessageText.ToString());
