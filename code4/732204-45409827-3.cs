           private string RoundTripCheck(Process p){
    
    
                StringBuilder result = new StringBuilder();
                string returned = "";
    
                p.Start();
    
                while (!p.StandardOutput.EndOfStream){
    
                    result.Append(p.StandardOutput.ReadLine());
    
                    if (result.ToString().Contains("Average")){
    
                        returned = result.ToString().Substring(result.ToString().IndexOf("Average ="))
                                         .Replace("Average =", "").Trim().Replace("ms", "").ToString();
                        break;
                    }
    
    
                    result.Clear();
    
                }
                
                return returned;
    
            }
