    Database db = DataRepository.GetDatabase();
    int result, session_id = 0;
    string kill_session, serial = null;
    string chk_lock = "SELECT l.session_id,v.serial# ,"
                    +"object_name FROM dba_objects o, gv$locked_object l, "
                    +"v$session v WHERE o.object_id = l.object_id and "
                    +"l.SESSION_ID=v.sid";
    DbDataReader rdr_blkAccount;
    try{
        //MY PROCESS RUNS HERE...
    }
    catch(Exception excep)
    {
        //...
    }
    finally
    {
        rdr_blkAccount = db.ExecuteReader(chk_lock);
        while (rdr_blkAccount.Read())
        {
            if (rdr_blkAccount[2].ToString().ToUpper() == "ACCOUNT")
            {
                session_id = Convert.ToInt32(rdr_blkAccount[0]);
                serial = session_id.ToString() + ','
                       + Convert.ToInt32(rdr_blkAccount[1]).ToString();
                kill_session = "alter system kill session '" + serial + "'";
                result = db.ExecuteNonQuery(kill_session);
                logger.Log( LogLevel.Warning 
                          , string.Format("Session_id '{0}' has been forcefully killed"
                                         , serial));
            }
        }
        rdr_blkAccount.Close();
    }
