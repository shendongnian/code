        private void sqtBtn_Click(object sender, EventArgs e)
        {
            outputList.Items.Clear();
            int itemValue, sqt;
            for (int i = 0; i < randomNumAmount; i++)
            {
                int.TryParse(randomList.Items[i].ToString(), out itemValue);
                outputList.Items.Add(Math.Sqrt(itemValue).ToString("f"));
            }
        }
