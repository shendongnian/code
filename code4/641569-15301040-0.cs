    // (1)
    public partial class PC : GenericPC
    {
        // (2)
        GenericPC baseInst = new GenericPC();
        public Control GetPC(…)
        {
            …
            // (3)
            return baseInst.GetPC(cbInst, dllSel, templ, dll, cert0, slaveIndex, BoxID);
        }
        public override void ValidateDynData(TextBox[] tb_dynData_Array, ref int result)
        {
            // (4)
            …
        }
    }
