        private void BtnDelete_Click(object sender, EventArgs e) {
            if (listBox.SelectedIndex == -1) {
                return;
            }
            // Remove each item in reverse order to maintain integrity
            var selectedIndices = new List<int>(listBox.SelectedIndices.Cast<int>());
            selectedIndices.Reverse();
            selectedIndices.ForEach(index => listBox.Items.RemoveAt(index));
        }
