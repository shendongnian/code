        public class DisableErrorHandler : TiffErrorHandler
        {
            public override void WarningHandler(Tiff tif, string method, string format, params object[] args)
            {
               // do nothing, ie, do not write warnings to console
            }
            public override void WarningHandlerExt(Tiff tif, object clientData, string method, string format, params object[] args) 
            {
               // do nothing ie, do not write warnings to console
            }
        }
