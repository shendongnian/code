    class Program
        {
            static void Main(string[] args)
            {
                Skype skype;
                skype = new SKYPE4COMLib.Skype();
                string SkypeID = args[1];
                Call call = skype.PlaceCall(SkypeID);
                do
                {
                    System.Threading.Thread.Sleep(1);
                } while (call.Status != TCallStatus.clsInProgress);
                call.StartVideoSend();
            }
        }
