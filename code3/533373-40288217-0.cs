    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Linq;
    using Overby.Extensions.Attachments; // PM> Install-Package Overby.Extensions.Attachments
    
    namespace AFS.AutoTx
    {
        public static class ErrorProviderExtensions
        {
            public static void TrackControl(this ErrorProvider ep, Control c)
            {
                var controls = ep.GetOrSetAttached(() => new HashSet<Control>()).Value;
                controls.Add(c);
            }
    
            public static void SetErrorWithTracking(this ErrorProvider ep, Control c, string error)
            {
                ep.TrackControl(c);          
                ep.SetError(c, error);
            }
    
            public static int GetErrorCount(this ErrorProvider ep)
            {
                var controls = ep.GetOrSetAttached(() => new HashSet<Control>()).Value;
    
                var errControls = from c in controls
                                  let err = ep.GetError(c)
                                  let hasErr = !string.IsNullOrEmpty(err)
                                  where hasErr
                                  select c;
    
                var errCount = errControls.Count();
                return errCount;
            }
    
            public static void ClearError(this ErrorProvider ep, Control c)
            {            
                ep.SetError(c, null);
            }
        }
    }
