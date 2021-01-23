    private void GetPing(){
    
                Dictionary<string, string> tempDictionary = FindIt(ctrl, svType);
                StringBuilder proxy = new StringBuilder();
    
                string roundTripTest = "";
                string location;
                int count = 0;  //Count is mainly there in case you don't get anything
    
                Process process = new Process{
    
                    StartInfo = new ProcessStartInfo{
                        FileName = "ping.exe",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
    
                    }
    
                };
    
                for (int i = 0; i < tempDictionary.Count; i++){
    
                    proxy.Append(tempDictionary.Keys.ElementAt(i));
    
                    process.StartInfo.Arguments = proxy.ToString();
    
                    do{
                        try{
    
                            roundTripTest = RoundTripCheck(process);
    
                        }
                        catch (Exception ex){
    
                            count++;
    
                        }
    
                        if (roundTripTest == null){
    
                            count++;
    
                        }
    
                        if (count == 10 || roundTripTest.Trim().Equals("")){
    
                            roundTripTest = "Server Unavailable";
    
                        }
    
                    } while (roundTripTest == null);
                }
    
                process.Dispose();
    
            }
    
    
