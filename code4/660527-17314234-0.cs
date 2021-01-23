                var sessionIdProperty = typeof(RemoteWebDriver).GetProperty("SessionId", BindingFlags.Instance | BindingFlags.NonPublic);
                if (sessionIdProperty != null)
                {
                    SessionId sessionId = sessionIdProperty.GetValue(driver, null) as SessionId;
                    if (sessionId == null)
                    {
                        Trace.TraceWarning("Could not obtain SessionId.");
                    }
                    else
                    {
                        Trace.TraceInformation("SessionId is " + sessionId.ToString());
                    }
                }
