    System.Threading.Thread KeyThread = new System.Threading.Thread(() => {
           //foreach process
           // press key now
           PostMessage(MemoryHandler.GetMainWindowHandle(), 
                  (int)KeyCodes.WMessages.WM_KEYDOWN, 
                  (int)KeyCodes.VKeys.VK_TAB, 0);
           System.Threading.Thread.Sleep(1000); // wait 1 second
           
           //foreach process
           // release keys again
           PostMessage(MemoryHandler.GetMainWindowHandle(), 
                  (int)KeyCodes.WMessages.WM_KEYUP, 
                  (int)KeyCodes.VKeys.VK_TAB, 0);
    });
