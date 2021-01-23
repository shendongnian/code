        public delegate void AddEventHandlerToSPDialogEvent(object sender, PDialogEventHandler e);
        public class SPDialogEventHandler : EventArgs
        {
          public int dialogResult { get; set; } // 0 or 1
          public string ReturnValues { get; set; } // can be url or any success/error message
          public SPDialogEventHandler(int result, string list)
          {
            ReturnValues = list;
            dialogResult = result;
          }
        }
