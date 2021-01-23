    private void radButtonCallEmptyTasks_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < int.Parse(radTextBoxWaitThreads.Text); i++)
            {
                // Create a task and supply a user delegate by using a lambda expression. 
                var taskA = new Task(() => EmptyTaskRequest(int.Parse(radTextBoxFloodDelay.Text), i));
                // Start the task.
                taskA.Start();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }
    private void EmptyTaskRequest(int delay, int count)
    {
        try
        {
            System.Threading.Thread.Sleep(delay);
            Debug.Print(count.ToString());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }
}
