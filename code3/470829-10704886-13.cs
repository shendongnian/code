    public class SMSManager : ManagerBase
    {
        public SMSManager(DataBlock smsDataBlock, DataBlock telephonesDataBlock) 
            : base(smsDataBlock)
        {
            SheetEvents.ButtonClick += OnButtonClick;   
        }
    
        public override void Dispose()
        {
            SheetEvents.ButtonClick -= OnButtonClick;
            base.Dispose();
        }
    }
