    bool AskRetry(Exception ex)
    {
      return MessageBox.Show(you know here...) == DialogResult.Retry;
    }
    
    void SomeFuncOrEventInGui()
    {
      re:try{ SomeThing(); }
      catch (Exception ex)
      {
        if (AskRetry(ex)) goto re;
        else Mange(ex); // or throw or log.., whatever...
      }
    }
