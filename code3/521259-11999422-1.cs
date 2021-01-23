     public static string GetStatusMessage(BeatSession status, string custom_message = "")
            {
                string msg = "";
                try
                {
                    switch (status)
                    {
                        case BeatSession.on_answered:
                            // msg will be here
                            break;
                        case BeatSession.on_ended:
                            // msg will be here
                            break;
                        case BeatSession.on_hanged_up:
                            // msg will be here
                            break;
                        case BeatSession.on_hold:
                            // msg will be here
                            break;
                        case BeatSession.on_new:
                            break;
                        case BeatSession.on_paused:
                            // msg will be here
                            break;
                        case BeatSession.on_timed_out:
                            // msg will be here
                            break;
                        case BeatSession.on_accepted:
                            // msg will be here
                            break;
                        default:
                            msg = "Unknown";
                            break;
                    }
    
                }
                catch (Exception ex)
                {
    
                    throw ex;
                }
                // Override message
                if (!String.IsNullOrEmpty(custom_message))
                {
                    msg = custom_message;
                }
    
                return msg;
            }
