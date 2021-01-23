    CrystalDecisions.Shared.TableLogOnInfo info = document.Database.Tables[iTable].LogOnInfo.Clone() as CrystalDecisions.Shared.TableLogOnInfo;
    
    info.ConnectionInfo.ServerName = <SERVER>;
    info.ConnectionInfo.DatabaseName = "";
    info.ConnectionInfo.UserID = <USER>;
    info.ConnectionInfo.Password = <PASSWORD>;
    		
    document.Database.Tables[iTable].ApplyLogOnInfo(info);
