    catch (System.Data.OracleClient.OracleException ex)
    {
        int code = ex.Code;
       // or
       
       string eCode = ex.ErrroCode;
        return false;
    }
    return true;  
