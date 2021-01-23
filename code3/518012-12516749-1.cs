    private void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
      if (e.Result.Confidence >= ConfidenceThreshold)
      {
        if (IsListening)
        {
          if (e.Result.Semantics["SysCommand"] != null)
          {
            switch (e.Result.Semantics["SysCommand"].Value.ToString())
            {
              case "PASSWORD":
                // The was waiting for this, now you can act on it
                break;
              default:
                // something else was said, reset!
                break;
            }
          }
        }
        else if (e.Result.Semantics["SysCommand"] != null)
        {
          if (e.Result.Semantics["SysCommand"].Value.ToString() == "STATUS")
          {
            // do stuff that prompts user for password
            IsListening = true;
          }
        }
      }
    }
