        private void Form1_Load(object sender, EventArgs e) {
            displayEventsBox.Items.AddRange(File.ReadAllLines(path));
        }
        void Save() {
            File.WriteAllLines(path, displayEventsBox.Items.Cast<string>());
        }
        string Format() {
            return txtTaskName.Text + "," + txtTaskDescription.Text + "," + txtDateCreated.Text + "," + txtDateCompleted.Text;
        }
        private void butAddTask_Click(object sender, EventArgs e) {
            displayEventsBox.Items.Add(Format());
            Save();
        }
        private void butDeleteTask_Click(object sender, EventArgs e) {
            displayEventsBox.Items.RemoveAt(displayEventsBox.SelectedIndex);
            Save();
        }
        private void butEditTask_Click(object sender, EventArgs e) {
            displayEventsBox.Items[displayEventsBox.SelectedIndex] = Format();
            Save();
        }
