    public partial class PC : GenericPC
    {
        public override Control GetPC(…)
        {
            …
            return base.GetPC(cbInst, dllSel, templ, dll, cert0, slaveIndex, BoxID);
        }
        public override void ValidateDynData(TextBox[] tb_dynData_Array, ref int result)
        {
            …
        }
    }
