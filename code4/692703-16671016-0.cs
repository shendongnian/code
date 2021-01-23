    private void Install()
            {
                var item = _installItems.Dequeue();
    
                item.ProgStage = ProgressStage.Install;
                RefreshPgBars();
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
               //insert psi arguments and file name here  
    
                Process installProc = System.Diagnostics.Process.Start(psi);//start installing
                installProc.WaitForExit();
    }
