    public void SetInstrumentInfo(Instrument instrument, InstrumentInfo info)
    {
        if (instrument == null || info == null)
        {
            return;
        }
        Thread.MemoryBarrier();
        instrumentInfos[instrument.Id] = info;
    }
    
    public InstrumentInfo GetInstrumentInfo(Instrument instrument)
    {
        var result = instrumentInfos[instrument.Id];
        Thread.MemoryBarrier();
        return result;
    }
