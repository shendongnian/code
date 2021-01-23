    List<string> startupAndLogonTasks = new List<string>();
    foreach (string taskName in st.GetTaskNames()) {
        using (Task task = st.OpenTask(taskName)) {
            if (task != null) {
                foreach (Trigger tr in task.Triggers) {
                    if (tr is OnSystemStartTrigger || tr is OnLogonTrigger) {
                        //  Do something, such as log the name, or store the task for later
                        startupAndLogonTasks.Add(task.Name);
                        //  break out and move to the next task
                        break;
                    }
                }
            }
        }
    }
