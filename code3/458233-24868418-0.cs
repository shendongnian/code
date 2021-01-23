    class RdtEvents : IVsRunningDocTableEvents
    {
        RdtEvents()
        {
            var rdt = Package.GetGlobalService(typeof(SVsRunningDocumentTable));
            uint evtCookie;
            rdt.AdviseRunningDocTableEvents(this, out evtCookie);
        }
        // ...
        int IVsRunningDocTableEvents.OnBeforeDocumentWindowShow(uint docCookie, int fFirstShow, IVsWindowFrame pFrame)
		{
            // ...
        }
    }
