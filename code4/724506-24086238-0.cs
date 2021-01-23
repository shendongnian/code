            try {
                windowId = pptApp.ProtectedViewWindows.Open(pptPath, 
                              PRESENTATION_FAKE_PASSWORD).HWND;
            } catch (Exception ex) {
                if (!ex.Message.Contains("could not open")) {
                    // Assume it is password protected.
                    _conversionUtil.LogError(
                          "Powerpoint seems to be password protected.",
                          _conversionRequest, ex);
                }
            }
