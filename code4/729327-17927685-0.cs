    internal class DebugEventMonitor {
        // DTE Events are strange in that if you don't hold a class-level reference
        // The event handles get silently garbage collected. Cool!
        private DTEEvents dteEvents;
        public DebugEventMonitor() {
            // Capture the DTEEvents object, then monitor when the 'Mode' Changes.
            dteEvents = DTE.Events.DTEEvents;                     
            this.dteEvents.ModeChanged += dteEvents_ModeChanged;
        }
        void dteEvents_ModeChanged(vsIDEMode LastMode) {
            // Attach to the process when the mode changes (but before the debugger starts).
            if (IntegrationPackage.VS_DTE.DTE.Mode == vsIDEMode.vsIDEModeDebug) {
                AttachToServiceEngineCommand.Attach();
            }
        }
    }
