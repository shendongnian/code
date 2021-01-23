        private async Task DoSomething()
        {
            await Task.Delay(5000);
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await DoSomething();
            MessageBox.Show("Finished");
        }
