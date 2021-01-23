    private const int maxDisplayTextLength = 5000;
    private string splitString = "";
    private int activityCount = 0;
    private string errorMessageBox = "";
    private bool errorMessageBoxNeedUpdate = true;
    private int errorMessageBoxCount = 0;
    private string filteredMessageBox = "";
    private int filteredMessageCount = 0;
    private bool filteredMessageBoxNeedUpdate = true;
    private string activityLogFilterKeyword = "Warning";
    string logHelperStringMaxSizeLimiter(string input)
    {
        // check if our buffer isn't getting bigger than our specified max. length
        if (input.Length > maxDisplayTextLength)
        {
            // discard the oldest data in our buffer (FIFO) so we have room for our newest values
            input = input.Substring(input.Length - maxDisplayTextLength);
        }
        return input;
    }
    private void logHelperIncoming(string msg)
    {
        msg = msg.Replace('\0', '\n'); // remove \0 NULL characters as they have special meanings in C# RichTextBox
        // add the new received string to our buffer
        splitString += msg;
        // filter out special strings 
        int searchIndexStart = splitString.Length - msg.Length;
        for (int e = searchIndexStart; e < splitString.Length; e++)
        {
            if (splitString[e] == '\n')
            {
                activityCount++;
                string subString = splitString.Substring(searchIndexStart, e - searchIndexStart) + "\n";
                searchIndexStart += e - searchIndexStart + 1; // update searchindex for next search
                string filterError = "error";
                // filter messages that start with error
                if (subString.Length > filterError.Length) // for this filter, the length should be at least length of error
                {
                    if (String.Compare(subString, 0, filterError, 0, 4, true) == 0)
                    {
                        errorMessageBox += subString;
                        errorMessageBoxNeedUpdate = true;
                        errorMessageBoxCount++;
                    }
                }
                // filter messages that start with XXX
                if (subString.Length > activityLogFilterKeyword.Length && activityLogFilterKeyword.Length != 0) // for this filter, the length should be at least length of error
                {
                    if (String.Compare(subString, 0, activityLogFilterKeyword, 0, activityLogFilterKeyword.Length, true) == 0)
                    {
                        filteredMessageBox += subString;
                        filteredMessageBoxNeedUpdate = true;
                        filteredMessageCount++;
                    }
                }
            }
        }
    }
    // outputs to main activity textbox
    private void Log(LogMsgType msgtype, string msg)
    {
        if (msgtype == LogMsgType.Incoming || msgtype == LogMsgType.Normal)
        {
            logHelperIncoming(msg);
        }
        else if (msgtype == LogMsgType.Outgoing)
        {
        }
        splitString = logHelperStringMaxSizeLimiter(splitString);
        filteredMessageBox = logHelperStringMaxSizeLimiter(filteredMessageBox);
        errorMessageBox = logHelperStringMaxSizeLimiter(errorMessageBox);
        uiTextActivity.Invoke(new EventHandler(delegate
        {
            // time to post our updated buffer to the UI
            uiTextActivity.Text = splitString;
            uiTextActivity.Update();
            // scroll to the newest data only if user has no focus on the 
            uiTextActivity.SelectionStart = uiTextActivity.TextLength; // make sure view is to the latest
            uiTextActivity.ScrollToCaret();
            uiLabelCounterActivity.Text = activityCount.ToString();
            if (errorMessageBoxNeedUpdate)
            {
                errorMessageBoxNeedUpdate = false;
                uiTextActivity.SelectionColor = Color.Red;
                // time to post our updated buffer to the UI
                uiTextboxErrorLog.Text = errorMessageBox;
                // scroll to the newest data only if user has no focus on the 
                uiTextboxErrorLog.SelectionStart = uiTextboxErrorLog.TextLength; // make sure view is to the latest
                uiTextboxErrorLog.ScrollToCaret();
                uiLabelCounterError.Text = errorMessageBoxCount.ToString();
            }
            if (filteredMessageBoxNeedUpdate)
            {
                filteredMessageBoxNeedUpdate = false;
                // time to post our updated buffer to the UI
                uiTextboxFilteredLog.Text = filteredMessageBox;
                // scroll to the newest data only if user has no focus on the 
                uiTextboxFilteredLog.SelectionStart = uiTextboxFilteredLog.TextLength; // make sure view is to the latest
                uiTextboxFilteredLog.ScrollToCaret();
                uiLabelCounterFiltered.Text = filteredMessageCount.ToString();
            }
            // extract value from filter and store to filter
            activityLogFilterKeyword = uiTextboxFilterKeyword.Text;
        }));
    }
