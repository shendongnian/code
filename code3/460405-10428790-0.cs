        private void btn_Say_Click(object sender, EventArgs e)
        {
            string text = tbx_Say.Text;
            tbx_Say.Text = "";
            if (status == 0)
            {
                if (text.Contains("Add") || text.Contains("add"))
                {
                    if (text.Contains("Task") || text.Contains("task"))
                    {
                        screen.btn_Tasks.PerformClick();
                        tbx_Anne.Text = "What should happen?";
                        status = 1;
                    }
                }
            }
            else if (status == 1) // to do
            {
                if (text != "")
                {
                    screen.task.tb_TaskToDo.Text = text;
                    tbx_Anne.Text = "On which date?";
                    status = 2;
                }
            }
            else if (status == 2) // date
            {
                DateTime date;
                if(DateTime.TryParse(text, new CultureInfo("nl-NL"), DateTimeStyles.None, out date))
                {
                    screen.task.dateTimePickerTask.Value = date;
                    tbx_Anne.Text = "And what time?";
                    status = 3;
                }
                else
                {
                    tbx_Anne.Text = "Please nter date as dd-mm-yyyy.";
                }
            }
            else if (status == 3) // time
            {
                int h;
                int m;
                if(text.Length == 5 && Int32.TryParse(text.Substring(0,2), out h) && text[2] == ':' && Int32.TryParse(text.Substring(3), out m))
                {
                    screen.task.tb_TimeTask.Text = text;
                    tbx_Anne.Text = "Do you want to add reminders?";
                    status = 4;
                }
                else
                {
                    tbx_Anne.Text = "Please insert time as hh:mm.";
                }
            }
        }
