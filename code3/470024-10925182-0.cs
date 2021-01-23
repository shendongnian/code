    interface IThingDoerA
    {
    }
    class ThingDoerA : IThingDoerA
    {
    }
    interface IThingDoerB
    {
    }
    class ThingDoerB : IThingDoerB
    {
        private readonly IThingDoerA _tda;
        public ThingDoerB(IThingDoerA tda)
        {
            _tda = tda;
        }
    }
    interface IThingDoerC
    {
    }
    class ThingDoerC : IThingDoerC
    {
        private readonly IThingDoerA _tda;
        private readonly IThingDoerB _tdb;
        public ThingDoerC(IThingDoerA tda, IThingDoerB tdb)
        {
            _tda = tda;
            _tdb = tdb;
        }
    }
    // I am the composition root.
    interface IWizBang
    {
        public void StartApp();
    }
    class WizBang : IWizBang
    {
        private readonly IThingDoerA _tda;
        private readonly IThingDoerC _tdc;
        public WizBang(IThingDoerA tda, IThingDoerC tdc)
        {
            _tda = tda;
            _tdc = tdc;
        }
        public void StartApp()
        {
            //TODO
            // _tda.Blah()
            // _tdc.Blah()
        }
    }
