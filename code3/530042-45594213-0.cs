        public class consoleService {
        private CancellationTokenSource cts;
        private TcpListener listener;
        private frmMain main;
        public bool started = false;
        public bool stopped = false;
		
	   public void start() {
            try {
                if (started) {
                    stop();
                }
                cts = new CancellationTokenSource();
                listener = new TcpListener(IPAddress.Any, CFDPInstanceData.Settings.RemoteConsolePort);
                listener.Start();
                Task.Run(() => {
                    AcceptClientsTask(listener, cts.Token);
                });
                started = true;
                stopped = false;
                functions.Logger.log("Started Remote Console on port " + CFDPInstanceData.Settings.RemoteConsolePort, "RemoteConsole", "General", LOGLEVEL.INFO);
            } catch (Exception E) {
                functions.Logger.log("Error starting remote console socket: " + E.Message, "RemoteConsole", "General", LOGLEVEL.ERROR);
            }
        }
        public void stop() {
            try {
                if (!started) { return; }
                stopped = false;
                cts.Cancel();
                listener.Stop();
                int attempt = 0;
                while (!stopped && attempt < GlobalSettings.ConsoleStopAttempts) {
                    attempt++;
                    Thread.Sleep(GlobalSettings.ConsoleStopAttemptsDelayMS);
                }
            } catch (Exception E) {
                functions.Logger.log("Error stopping remote console socket: " + E.Message, "RemoteConsole", "General", LOGLEVEL.ERROR);
            } finally {
                started = false;
            }
        }
		
		 void AcceptClientsTask(TcpListener listener, CancellationToken ct) {
            try {
                while (!ct.IsCancellationRequested) {
                    try {
                        TcpClient client = listener.AcceptTcpClient();
                        if (!ct.IsCancellationRequested) {
                            functions.Logger.log("Client connected from " + client.Client.RemoteEndPoint.ToString(), "RemoteConsole", "General", LOGLEVEL.DEBUG);
                            ParseAndReply(client, ct);
                        }
                    } catch (SocketException e) {
                        if (e.SocketErrorCode == SocketError.Interrupted) {
                            break;
                        } else {
                            throw e;
                        }
                     } catch (Exception E) {
                        functions.Logger.log("Error in Remote Console Loop: " + E.Message, "RemoteConsole", "General", LOGLEVEL.ERROR);
                    }
                }
                functions.Logger.log("Stopping Remote Console Loop", "RemoteConsole", "General", LOGLEVEL.DEBUG); 
            } catch (Exception E) {
                functions.Logger.log("Error in Remote Console: " + E.Message, "RemoteConsole", "General", LOGLEVEL.ERROR);
            } finally {
                stopped = true;
            }
            functions.Logger.log("Stopping Remote Console", "RemoteConsole", "General", LOGLEVEL.INFO);
            
        }
		}
