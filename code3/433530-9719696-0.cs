    public class MyClient
    {
        private delegate void CommandHandler(string data);
        private TextSocket socket_ = new TextSocket(); // text socket we created
        private Dictionary<string, CommandHandler> cmdMap_ = new Dictionary<string, CommandHandler>();
        public MyClient()
        {
            // Initialise our map full of delegates
            cmdMap_["CMD1"] = (data) => { /* handle this command */ };
            cmdMap_["CMD2"] = (data) => { /* handler for this one */ };
            socket_.OnLineReceived += (line) 
            {
                if(!string.IsNullOrEmpty(line)) // sanity check
                {
                    string cmd;
                    string data;
                    int pos = line.IndexOf(' ');
                    if(pos != -1)
                    {
                        cmd = line.Substring(0, pos);
                        data = line.Substring(pos + 1);
                    }
                    else
                        cmd = line;
                    if(cmdMap_.ContainsKey(cmd))
                        cmdMap_[cmd](data);
                }
            }; 
        }
    }
