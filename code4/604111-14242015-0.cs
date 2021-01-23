    [Cmdlet(VerbsCommon.Find, "Numbers")]
    public class FindNumbers: Cmdlet
    {
        [Parameter(ValueFromPipeline = true)] // The data appear in this variable
        public int[] Input { get; set; }
        protected override void ProcessRecord()
        {
            foreach (var variable in Input)
            {
                if (variable % 2 == 0)
                {
                    WriteObject(variable);
                }
            }
        }
    }
