      protected void Page_LoadComplete(object sender, EventArgs e) {
         if (!ScriptManager.GetCurrent(this).IsNavigating && (IsCallback || IsInAsyncPostback())) {
            var state=new NameValueCollection();
            //OnCallbackHistory(state);	// this gets state for all interested parties
            if (state.Count != 0) {
               string key=ViewState["HistoryStateKey"] as string;	// empty on first AJAX call
               if (string.IsNullOrEmpty(key) || ScriptManager.GetCurrent(this).EnableHistory) {
                  key=CallbackHistoryKeyRoot+Interlocked.Increment(ref callbackHashKey).ToString();
                  ViewState["HistoryStateKey"]=key;
                  ScriptManager.GetCurrent(this).AddHistoryPoint("", key);
               }
               Session[key]=state;
            }
         }
      }
