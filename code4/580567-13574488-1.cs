    }
    catch (Exception e)
    {
      bool isAdsExc = e is Advantage.Data.Provider.AdsException;
      if (isAdsExc)
      {
        tried++;
        System.Threading.Thread.Sleep(1000);
      }
      if (tried > 5 || !isAdsExc)
      {
        txn.Rollback();
        log.Error(" ...
        ...
      }
    }
    finally
    {
