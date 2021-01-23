    private void ServerStop()
    {
         if (serverRunning)
         {
              consoleWrite("* Stopping server . . .\n", Color.Orange);
              l.Stop();
              serverRunning = false;
              consoleWrite("* Server stopped !\n\n", Color.Lime);
              dataGridViewConnections.Rows.Clear(); // Clear connections
         }
         else
         {
              consoleWrite("* ERROR: Server already stopped !\n\n", Color.Red);
         }
     }
