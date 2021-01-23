     private void button1_Click(object sender, EventArgs e)
        {
            if (restart)
            {
                restart = false;
                _proConsumer.ReStart();                
            }
            item++;
            _proConsumer.EnQueueWorkItem(item.ToString());
        }
