     ActionResult actionResult = null;
     switch (methodId)
        {
          case 1:
          case 5: // PVT, PVT-WMT
          {
              actionResult =  GetP1Report("33996",false)  as ActionResult;
              break;
           }
         }
     return actionResult ?? new View(); 
