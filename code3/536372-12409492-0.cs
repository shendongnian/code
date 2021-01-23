    // I made this method up because I do not know where your messages really come from.
    // => ADJUST TO YOUR NEEDS.
    private void onNewMessageArriving(string messageId)
    {
      videomessage arrivingMessage = new videomessage(messageId);
      _messagesToApprove.Add(arrivingMessage);
    }
