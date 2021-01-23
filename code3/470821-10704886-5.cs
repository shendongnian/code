    public class SMSManager : ManagerBase
    {
        public SMSManager(DataBlock smsDataBlock, DataBlock telephonesDataBlock) :
            base(smsDataBlock)
        {
            SheetEvents.ButtonClick += OnButtonClick;   
        }
    
        public override void Dispose()
        {
            base.Dispose();
            SheetEvents.ButtonClick -= OnButtonClick;
        }
    }
