    public ProcessModule MainModule
    {
        get
        {
            if (this.OperatingSystem.Platform == PlatformID.Win32NT)
            {
                this.EnsureState((Process.State)3);
                ModuleInfo firstModuleInfo = 
                    NtProcessManager.GetFirstModuleInfo(this.processId);
                return new ProcessModule(firstModuleInfo);
            }
            ProcessModuleCollection processModuleCollection = this.Modules;
            this.EnsureState(Process.State.HaveProcessInfo);
            foreach (ProcessModule processModule in processModuleCollection)
            {
                if (processModule.moduleInfo.Id == this.processInfo.mainModuleId)
                {
                    return processModule;
                }
            }
            return null;
        }
    }
