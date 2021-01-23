    class Program
        {
            static string SkypeID = "";
            static void Main(string[] args)
            {
                Skype skype;
                skype = new SKYPE4COMLib.Skype();
                skype.CallStatus += new _ISkypeEvents_CallStatusEventHandler(skype_CallStatus);
                Call call = skype.PlaceCall(SkypeID);
    
                Console.ReadKey();
            }
    
            static void skype_CallStatus(Call pCall, TCallStatus Status)
            {
                if (Status == TCallStatus.clsInProgress && pCall.PartnerHandle == SkypeID) { pCall.StartVideoSend(); }
            }
        }
