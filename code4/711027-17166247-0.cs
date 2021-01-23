    public void Close() {
      if (base.GetState(262144)) {
        throw new InvalidOperationException(SR.GetString("ClosingWhileCreatingHandle", new object[]		  {
			    "Close"
		    }));
      }
      if (base.IsHandleCreated) {
        this.closeReason = CloseReason.UserClosing;
        base.SendMessage(16, 0, 0);
        return;
      }
      base.Dispose();
    }
