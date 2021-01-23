      for(var i = 0; i < nodeCount; i++)
      {
          string kwd = System.Uri.EscapeDataString(search[i].SelectSingleNode("query").InnerText);
          ThreadPool.QueUserWorkItem((WaitCallback)startRun, kwd);
      }
