    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    namespace Test
    {
        [Cmdlet(VerbsCommon.Get, "WhatIf", SupportsShouldProcess = true)]
        public class GetWhatIf : PSCmdlet
        {
            // Methods
            protected override void BeginProcessing()
            {
                this.WriteObject(this.MyInvocation.BoundParameters.ContainsKey("WhatIf").ToString());
            }
        }
    }
